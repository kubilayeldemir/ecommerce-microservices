using UserService.Models;

namespace UserService.V1.Models.ResponseModels
{
    public class JwtResponseModel
    {
        public UserResponseModel User { get; set; }
        public string Jwt { get; set; }

        public JwtResponseModel(User user, string jwt)
        {
            User = new UserResponseModel(user.Email, user.Role, user.Name, user.LastName);
            Jwt = jwt;
        }
    }
}