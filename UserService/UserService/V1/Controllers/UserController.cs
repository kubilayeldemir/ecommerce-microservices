using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            var (isAuthenticated, user) = await _userService.AuthenticateUser(model.Email, model.Password);
            if (!isAuthenticated)
            {
                return Unauthorized();
            }
            var jwtToken = await _userService.GenerateJwtTokenForUser(user);
            return Ok(new JwtResponseModel(user, jwtToken));
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterRequestModel model)
        {
            var user = await _userService.RegisterUser(model);
            if (user == null)
            {
                return BadRequest(new
                {
                    Message = $"User with email {model.Email} already exists.",
                    Code = 400001
                });
            }
            return Ok(new UserResponseModel(user.Email, user.Role,user.Name,user.LastName));
        }
    }
}