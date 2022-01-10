using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repositories
{
    public class UserRepository : IUserRepository
    {
        //TODO use postgresql and dapper to store and retrieve user data
        private static Dictionary<string,User> users = new Dictionary<string,User>();

        public async Task<bool> CheckIfUserCredentialsCorrect(string email, string password)
        {
            // SELECT EXISTS (
            //     SELECT * FROM login_details WHERE username = ? AND password = ?
            //     )
            if (users.ContainsKey(email))
            {
                var userFound = users[email];
                if (userFound.Email == email && userFound.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return users.ContainsKey(email) ? users[email] : null;
        }
        
        public async Task<string> GetUserSalt(string email)
        {
            return users.ContainsKey(email) ? users[email].Salt : null;
        }

        public async Task<User> SaveUser(User user)
        {
            users[user.Email] = user;
            return user;
        }
    }
}