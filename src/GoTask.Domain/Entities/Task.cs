namespace GoTask.Domain.Entities
{
    public class Task
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public ICollection<Comment> Comments { get; set; } = default!;
        public long UserId { get; set; }
        public User User { get; set; } = default!;
    }
}
