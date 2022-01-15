using System;
using System.Threading.Tasks;
using UserService.Helpers;
using UserService.Models;
using UserService.Repositories;
using UserService.V1.Models.RequestModels;

namespace UserService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<(bool isAuthenticated, User user)> AuthenticateUser(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);
            var userSalt = user.Salt;
            var hashedModel = EncryptionHelper.EncryptData(password, userSalt);
            var hashedPassword = hashedModel.hashedData;
            var isCredentialsCorrect = user.CheckIfUserCredentialsCorrect(email, hashedPassword);
            return (isCredentialsCorrect, user);
        }

        public async Task<string> GenerateJwtTokenForUser(User user)
        {
            return JwtHelper.GenerateJwtToken(user);
        }

        public async Task<User> RegisterUser(UserRegisterRequestModel userRegisterModel)
        {
            var (hashedData, salt) = EncryptionHelper.EncryptData(userRegisterModel.Password);
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = userRegisterModel.Email,
                Password = hashedData,
                Salt = salt,
                Role = "user",
                Name = userRegisterModel.Name,
                LastName = userRegisterModel.LastName,
                CreatedAt = DateTime.UtcNow
            };
            try
            {
                await _userRepository.SaveUser(user);
            }
            catch (Exception e)
            {
                return null;
            }
            return user;
        }
    }
}