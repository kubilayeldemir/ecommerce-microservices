﻿using System;
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

        public async Task<string> AuthenticateUserAndGenerateJwtToken(string email, string password)
        {
            var isCredentialsCorrect = await _userRepository.CheckIfUserCredentialsCorrect(email, password);
            if (!isCredentialsCorrect) return null;
            var user = await _userRepository.GetUserByEmail(email);
            return JwtHelper.GenerateJwtToken(user);
        }

        public async Task<User> RegisterUser(string email, string password)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = email,
                Password = password,
                Salt = Guid.Empty.ToString()
            };
            await _userRepository.SaveUser(user);
            return user;
        }

        private async Task<bool> AuthenticateUser(string email, string password)
        {
            return await _userRepository.CheckIfUserCredentialsCorrect(email, password);
        }
    }
}