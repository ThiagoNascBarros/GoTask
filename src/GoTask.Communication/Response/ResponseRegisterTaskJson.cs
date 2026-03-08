using GoTask.Domain.Enum;
namespace GoTask.Communication.Response;

public record ResponseRegisterTaskJson(string Title, string Description, EStatus Status) { }