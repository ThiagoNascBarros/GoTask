using GoTask.Exception.Base;
using System.Net;

namespace GoTask.Exception.Exceptions
{
    public class InvalidLoginException : GoTaskException
    {
        public InvalidLoginException() : base(ResourceErroMessages.INVALID_LOGIN_ERROR)
        {
        }

        public override int StatusCode => (int)HttpStatusCode.Unauthorized;

        public override List<string> GetErrors()
        {
            return [Message];
        }

    }
}
