namespace GoTask.Exception.Base
{
    public abstract class GoTaskException : SystemException
    {
        protected GoTaskException(string message) : base(message)
        {

        }

        public abstract int StatusCode { get; }
        public abstract List<string> GetErrors();
    }
}
