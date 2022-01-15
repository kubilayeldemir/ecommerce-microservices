using System.Threading.Tasks;
using UserService.Models;
using UserService.V1.Models.RequestModels;

namespace UserService.Services
{
    public interface IUserService
    {
        Task<(bool isAuthenticated,User user)> AuthenticateUser(string email, string password);
        Task<string> GenerateJwtTokenForUser(User user);
        Task<User> RegisterUser(UserRegisterRequestModel userRegisterModel);
    }
}