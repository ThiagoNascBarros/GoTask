namespace GoTask.Communication.Requests;

public class RequestRegisterTaskJson(string Title, string Description, string Status, long UserId)
{
    public string Title { get; init; } = Title;
    public string Description { get; init; } = Description;
    public string Status { get; init; } = Status;
    public long UserId { get; init; } = UserId;
}