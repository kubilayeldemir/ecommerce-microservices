using System.Threading.Tasks;
using Clients.Interfaces;
using Clients.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginRequestModel loginRequestModel)
        {
            var responseModel = await _userRepository.LoginUser(loginRequestModel);
            if (responseModel == null)
            {
                return Unauthorized();
            }
            return Ok(responseModel);
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterRequestModel registerRequestModel)
        {
            var responseModel = await _userRepository.RegisterUser(registerRequestModel);
            if (responseModel == null)
            {
                return BadRequest(new
                {
                    Message = $"User with email {registerRequestModel.Email} already exists.",
                    Code = 400001
                });
            }
            return Ok(responseModel);
        }
    }
}