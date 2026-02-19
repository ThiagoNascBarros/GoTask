namespace GoTask.Communication.Response
{
    public class ResponseErroJson
    {

        public List<string> ErroMessage { get; set; }

        public ResponseErroJson(string errors)
        {
            this.ErroMessage = [errors];
        }

        public ResponseErroJson(List<string> erroMessage)
        {
            ErroMessage = erroMessage;
        }
    }
}
