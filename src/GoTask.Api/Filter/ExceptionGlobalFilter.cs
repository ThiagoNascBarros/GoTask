using GoTask.Communication.Response;
using GoTask.Exception;
using GoTask.Exception.Base;
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
            var e = (GoTaskException)context.Exception;
            var erroResponse = new ResponseErroJson(e.GetErrors());

            context.HttpContext.Response.StatusCode = e.StatusCode;
            context.Result = new ObjectResult(erroResponse);
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
