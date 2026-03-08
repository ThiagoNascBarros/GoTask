using GoTask.Application.UseCases.Tasks.GetAll;
using GoTask.Application.UseCases.Tasks.Register;
using GoTask.Application.UseCases.Tasks.Update;
using GoTask.Communication.Requests;
using GoTask.Communication.Response;
using GoTask.Domain.Security.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TasksController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterTaskJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErroJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromServices] ITaskRegisterUseCase useCase,
            [FromServices] IAuthDecode _decode,
            [FromBody] RequestRegisterTaskJson request)
        {
            var user = await _decode.DecodeTokenToUser();
            var response = await useCase.Execute(request, user);
            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ResponseGetAllTaskJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErroJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(
            [FromServices] ITaskGetAllUseCase useCase,
            [FromServices] IAuthDecode _decode
        )
        {
            var user = await _decode.DecodeTokenToUser();
            var response = await useCase.Execute(user);
            return Ok(response);
        }
        
        [HttpPut]
        [ProducesResponseType(typeof(ResponseUpdateTaskJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(
            [FromServices] ITaskUpdateUseCase useCase,
            [FromBody] RequestUpdateTaskJson request)
        {
            var response = await useCase.Execute(request);
            return Ok(response);
        }

    }
}