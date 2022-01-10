using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repositories
{
    public class UserRepository : IUserRepository
    {
        //TODO use postgresql and dapper to store and retrieve user data
        private static List<User> users = new List<User>();

        public async Task<bool> CheckIfUserCredentialsCorrect(string email, string password)
        {
            // SELECT EXISTS (
            //     SELECT * FROM login_details WHERE username = ? AND password = ?
            //     )

            var userFound = users.Find(u => u.Email == email && u.Password == password);
            return userFound != null;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return users.Find(x => x.Email == email);
        }

        public async Task<User> SaveUser(User user)
        {
            users.Add(user);
            return user;
        }
    }
}