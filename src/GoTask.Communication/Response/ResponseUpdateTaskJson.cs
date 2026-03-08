using GoTask.Domain.Enum;

namespace GoTask.Communication.Response;

public record ResponseUpdateTaskJson(string Title, string Description, EStatus Status) { }