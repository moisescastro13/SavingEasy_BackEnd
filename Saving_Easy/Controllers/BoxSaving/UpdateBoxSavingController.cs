using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Saving_Easy.Controllers.BoxSaving
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateBoxSavingController : ControllerBase
    {
        [HttpPut] public async Task<IActionResult> Put()
        {

            return Ok();
        }
    }
}
