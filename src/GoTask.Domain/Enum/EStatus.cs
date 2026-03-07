using System.ComponentModel.DataAnnotations;

namespace GoTask.Domain.Enum
{
    public enum EStatus
    {
        [Display(Name = "To do")]
        ToDo = 0,
        [Display(Name = "In progress")]
        InProgress = 1,
        [Display(Name = "Done")]
        Done = 2,
    }
}
