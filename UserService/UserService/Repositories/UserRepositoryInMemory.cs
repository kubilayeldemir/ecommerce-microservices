using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repositories
{
    public class UserRepositoryInMemory : IUserRepository
    {
        private static Dictionary<string, User> users = new Dictionary<string, User>();

        public async Task<User> GetUserByEmail(string email)
        {
            return users.ContainsKey(email) ? users[email] : null;
        }

        public async Task<User> SaveUser(User user)
        {
            users[user.Email] = user;
            return user;
        }
    }
}