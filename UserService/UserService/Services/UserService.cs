using System;
using System.Threading.Tasks;
using UserService.Helpers;
using UserService.Models;
using UserService.Repositories;

namespace UserService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<(bool isAuthenticated,User user)> AuthenticateUser(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);
            var userSalt = user.Salt;
            var hashedModel = EncryptionHelper.EncryptData(password, userSalt);
            var hashedPassword = hashedModel.hashedData;
            var isCredentialsCorrect = user.CheckIfUserCredentialsCorrect(email, hashedPassword);
            return (isCredentialsCorrect,user); 
        }

        public async Task<string> GenerateJwtTokenForUser(User user)
        {
            return JwtHelper.GenerateJwtToken(user);
        }

        public async Task<User> RegisterUser(string email, string password)
        {
            var hashedModel = EncryptionHelper.EncryptData(password);
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = email,
                Password = hashedModel.HashedData,
                Salt = hashedModel.Salt,
                Role = "user",
                CreatedAt = DateTime.UtcNow
            };
            await _userRepository.SaveUser(user);
            return user;
        }
    }
}