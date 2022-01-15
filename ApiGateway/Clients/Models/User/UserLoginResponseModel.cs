namespace Clients.Models.User
{
    public class UserLoginResponseModel
    {
        public UserResponseModel User { get; set; }
        public string Jwt { get; set; }
    }
}