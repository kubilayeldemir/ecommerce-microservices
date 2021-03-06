using System;
using System.Text.Json.Serialization;

namespace UserService.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime CreatedAt { get; set; }
        private string JwtToken { get; set; }

        public bool CheckIfUserCredentialsCorrect(string email, string password)
        {
            return Email == email && Password == password;
        }
    }
}