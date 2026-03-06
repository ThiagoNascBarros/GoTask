namespace GoTask.Communication.Response;

public class ResponseRegisterTaskJson(string Title, string Description, string Status)
{
    public string Title { get; init; } = Title;
    public string Description { get; init; } = Description;
    public string Status { get; init; } = Status;

    public void Deconstruct(out string Title, out string Description, out string Status)
    {
        Title = this.Title;
        Description = this.Description;
        Status = this.Status;
    }
}