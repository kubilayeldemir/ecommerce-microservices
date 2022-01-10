using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CheckIfUserCredentialsCorrect(string email, string password);
        Task<User> GetUserByEmail(string email);
        Task<User> SaveUser(User user);
    }
}