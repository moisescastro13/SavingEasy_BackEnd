using Application.Dto.BoxSaving;
using Application.interfaces.Authorization;
using Application.Interfaces.BoxSavings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Saving_Easy.Controllers.BoxSaving
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CreateBoxSavingController : ControllerBase
    {
        private readonly ICreateBoxSavingService _createBoxSavingService;
        private readonly IJWTTokenService _jwtTokenService;
        public CreateBoxSavingController(ICreateBoxSavingService createBoxSavingService, IJWTTokenService jwtTokenService)
        {
            _createBoxSavingService = createBoxSavingService;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBoxSavingDto createBoxSavingDto, CancellationToken cancellationToken = default)
        {
            var token = Request.Headers[HeaderNames.Authorization];
            var userId = _jwtTokenService.GetClaim(token.ToString(), "nameid");
            await _createBoxSavingService.Create(Guid.Parse(userId), createBoxSavingDto, cancellationToken);
            return NoContent();
        }


    }
}
