using GoTask.Exception.Base;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GoTask.Exception.Exceptions
{
    public class ErrorOnGetTaskToDelete : GoTaskException
    {
        List<string> errors;

        public override int StatusCode => (int) HttpStatusCode.BadRequest;

        public ErrorOnGetTaskToDelete(List<string> errorMessages) : base(string.Empty)
        {
            errors = errorMessages;
        }

        public override List<string> GetErrors()
        {
            return errors; 
        }
    }
}
