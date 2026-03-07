using GoTask.Communication.Response;
using GoTask.Exception;
using GoTask.Exception.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GoTask.Api.Filter
{
    public class ExceptionGlobalFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionGlobalFilter> _logger;
        
        public ExceptionGlobalFilter(ILogger<ExceptionGlobalFilter> logger)
        {
            _logger = logger;
        }
        
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
            _logger.LogError(context.Exception, "Erro inesperado ocorreu");

            context.HttpContext.Response.StatusCode = e.StatusCode;
            context.Result = new ObjectResult(erroResponse);
        }

        private void ThrowUnkowError(ExceptionContext context)
        {
            // Utilizando Resouce para centralizar as mensagens de erro
            var erroResponse = new ResponseErroJson(ResourceErroMessages.UNKNOWN_ERROR);
            _logger.LogError(context.Exception, "Erro inesperado ocorreu");
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(erroResponse);
        }

    }
}
