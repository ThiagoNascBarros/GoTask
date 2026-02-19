using GoTask.Application.UseCases.User.Register;
using GoTask.Communication.Requests;
using GoTask.Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace GoTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErroJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RequestRegisterUserJson request, [FromServices] IUserRegisterUseCase useCase)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
