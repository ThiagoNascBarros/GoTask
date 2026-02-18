namespace GoTask.Domain.Entities
{
    public class Comment
    {

        public long Id { get; set; }
        public string Body { get; set; } = string.Empty;
        public long TaskId { get; set; }
        public Task Task { get; set; } = default!;
    }
}
