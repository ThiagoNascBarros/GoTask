using GoTask.Domain.Enum;
namespace GoTask.Communication.Response;

public class ResponseGetAllTaskJson(long Id, string Title, string Description, EStatus Status)
{
    public long Id { get; set; } = Id;
    public string? Title { get; set; } = Title;
    public string? Description { get; set; } = Description;
    public EStatus Status { get; set; } = Status;
}