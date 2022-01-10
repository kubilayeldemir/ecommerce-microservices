namespace UserService.V1.Models.ResponseModels
{
    public class JwtResponseModel
    {
        public string Jwt { get; set; }

        public JwtResponseModel(string jwt)
        {
            Jwt = jwt;
        }
    }
}