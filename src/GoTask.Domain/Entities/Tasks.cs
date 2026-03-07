using System.ComponentModel.DataAnnotations.Schema;
using GoTask.Domain.Enum;

namespace GoTask.Domain.Entities
{
    [Table("Task")]
    public class Tasks
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public EStatus Status { get; set; }
        public ICollection<Comment> Comments { get; set; } = default!;
        public long UserId { get; set; }
        public User User { get; set; } = default!;
    }
}
