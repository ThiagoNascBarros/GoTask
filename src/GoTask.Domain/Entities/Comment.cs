namespace GoTask.Domain.Entities
{
    public class Comment
    {

        public long Id { get; set; }
        public string Body { get; set; } = string.Empty;
        public long TasksId { get; set; }
        public Tasks Task { get; set; } = default!;
    }
}
