using Application.Dto.User;
using Application.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace Saving_Easy.Controllers.User
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRegisterService _userRegisterService;
        private readonly ILoginService _loginService;
        public UserController(IUserRegisterService userRegisterService, ILoginService loginService)
        {
            _userRegisterService = userRegisterService;
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<ActionResult<ReadUserDto>> Create([FromBody] CreateUserDto userDto, CancellationToken cancellationToken = default)
        {
            var user = await _userRegisterService.Register(userDto, cancellationToken);
            return Ok(user);
        }
        [HttpPost("Authentication")]
        public async Task<ActionResult> Authenticate([FromBody] AuthenticationDto authenticationDto, CancellationToken cancellationToken = default)
        {
            var token = await _loginService.Authenticate(authenticationDto, cancellationToken);
            return Ok(token);
        }
    }
}
