using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Services
{
    public interface IUserService
    {
        Task<(bool isAuthenticated,User user)> AuthenticateUser(string email, string password);
        Task<string> GenerateJwtTokenForUser(User user);
        Task<User> RegisterUser(string email, string password);
    }
}