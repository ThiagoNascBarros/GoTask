using GoTask.Domain.Enum;

namespace GoTask.Communication.Requests;

public class RequestUpdateTaskJson
{
    public string Title { get; set; }
    public string Description { get; set; }
    public EStatus Status { get; set; }

    public RequestUpdateTaskJson(string title, string description, EStatus status)
    {
        Title = title;
        Description = description;
        Status = status;
    }
}