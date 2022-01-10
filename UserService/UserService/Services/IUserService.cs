using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Services
{
    public interface IUserService
    {
        Task<string> AuthenticateUserAndGenerateJwtToken(string email, string password);
        Task<User> RegisterUser(string email, string password);
    }
}