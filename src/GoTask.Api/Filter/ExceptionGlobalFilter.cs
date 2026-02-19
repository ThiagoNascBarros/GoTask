using GoTask.Communication.Response;
using GoTask.Exception;
using GoTask.Exception.Base;
using GoTask.Exception.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GoTask.Api.Filter
{
    public class ExceptionGlobalFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is GoTaskException)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnkowError(context);
            }
        }

        private void HandleProjectException(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidationException)
            {
                var e = (ErrorOnValidationException)context.Exception;

                var erroResponse = new ResponseErroJson(e.Errors);
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(erroResponse);
            }
            else
            {
                var erroResponse = new ResponseErroJson(context.Exception.Message);
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Result = new ObjectResult(erroResponse);
            }
        }

        private void ThrowUnkowError(ExceptionContext context)
        {
            // Utilizando Resouce para centralizar as mensagens de erro
            var erroResponse = new ResponseErroJson(ResourceErroMessages.UNKNOWN_ERROR);
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(erroResponse);
        }

    }
}
