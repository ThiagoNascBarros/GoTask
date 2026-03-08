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

        public void Update(Tasks task)
        {
            if (task.Title != null)
            {
                this.Title = task.Title;
            }

            if (task.Description != null)
            {
                this.Description = task.Description;
            }

            if (task.Status != null)
            {
                this.Status = task.Status;
            }
        }
    }
    
}