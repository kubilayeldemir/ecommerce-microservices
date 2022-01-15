using System.Threading.Tasks;
using Clients.Models.User;

namespace Clients.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserLoginResponseModel> LoginUser(UserLoginRequestModel loginRequestModel);
        public Task<UserResponseModel> RegisterUser(UserRegisterRequestModel loginRequestModel);
    }
}