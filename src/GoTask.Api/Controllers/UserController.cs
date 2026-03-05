using GoTask.Application.UseCases.User.Login;
using GoTask.Application.UseCases.User.Register;
using GoTask.Communication.Requests;
using GoTask.Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace GoTask.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost("auth/register")]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErroJson), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Register([FromBody] RequestRegisterUserJson request, [FromServices] IUserRegisterUseCase useCase)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPost("auth/login")]
        [ProducesResponseType(typeof(ResponseLoginUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErroJson), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(
            [FromServices] IUserLoginUseCase useCase,
            [FromBody] RequestLoginUserJson request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }

    }
}
