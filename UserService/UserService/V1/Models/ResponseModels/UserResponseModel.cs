namespace UserService.V1.Models.ResponseModels
{
    public class UserResponseModel
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public UserResponseModel(string email, string role, string name, string lastName)
        {
            Email = email;
            Role = role;
            Name = name;
            LastName = lastName;
        }
    }
}