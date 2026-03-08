using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using GoTask.Domain.Enum;

namespace GoTask.Communication.Requests;

public class RequestRegisterTaskJson(string Title, string Description, EStatus Status)
{
    public string Title { get; init; } = Title;
    public string Description { get; init; } = Description;
    public EStatus Status { get; init; } = Status;
}