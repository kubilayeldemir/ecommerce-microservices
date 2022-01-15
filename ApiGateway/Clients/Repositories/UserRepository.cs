using System.Threading.Tasks;
using Clients.Interfaces;
using Clients.Models.User;

namespace Clients.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IClient _client;

        public UserRepository(IClient client)
        {
            _client = client;
            //_client.SetBaseAddress(Environment.GetEnvironmentVariable("USER_SERVICE"));
            _client.SetBaseAddress("https://localhost:8091/");
        }

        public async Task<UserLoginResponseModel> LoginUser(UserLoginRequestModel loginRequestModel)
        {
            var endPoint = "api/v1/User/login";
            var x = await _client.PostAsync<UserLoginResponseModel>(endPoint, loginRequestModel);
            return x;
        }
        
        public async Task<UserResponseModel> RegisterUser(UserRegisterRequestModel loginRequestModel)
        {
            var endPoint = "api/v1/User/register";
            return await _client.PostAsync<UserResponseModel>(endPoint, loginRequestModel);
        }
    }
}