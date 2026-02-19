using GoTask.Exception.Base;

namespace GoTask.Exception.Exceptions
{
    public class ErrorOnValidationException : GoTaskException
    {
        public List<string> Errors { get; set; }
        public ErrorOnValidationException(List<string> errorMessages)
        {
            this.Errors = errorMessages;
        }
    }
}
