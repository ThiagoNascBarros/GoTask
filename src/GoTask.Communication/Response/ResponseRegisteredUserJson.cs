namespace GoTask.Communication.Response
{
    public record ResponseRegisteredUserJson(string Name, string Token)
    {
        public ResponseRegisteredUserJson() : this(string.Empty, string.Empty)
        {
        }
    }
}
