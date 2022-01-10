using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UserService.Services;
using UserService.V1.Models.RequestModels;
using UserService.V1.Models.ResponseModels;

namespace UserService.V1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> AuthenticateUser([FromBody] UserLoginRequestModel model)
        {
            var jwtToken = await _userService.AuthenticateUserAndGenerateJwtToken(model.Email, model.Password);
            if (jwtToken.IsNullOrEmpty())
            {
                return Unauthorized();
            }
            return Ok(new JwtResponseModel(jwtToken));
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserLoginRequestModel model)
        {
            var user = await _userService.RegisterUser(model.Email, model.Password);
            return Ok(new UserResponseModel(user.Email, user.Role,user.Name,user.LastName));
        }
    }
}