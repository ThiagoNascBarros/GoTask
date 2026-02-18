using GoTask.Application.UseCases.User.Register;
using GoTask.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace GoTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RequestRegisterUserJson request, [FromServices] IUserRegisterUseCase useCase)
        {
            try
            {
                await useCase.Execute(request);

                return Created(string.Empty, null);
            }
            catch (ArgumentException err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
