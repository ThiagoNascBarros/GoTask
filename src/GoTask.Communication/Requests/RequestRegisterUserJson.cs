namespace GoTask.Communication.Requests
{
    public record RequestRegisterUserJson(
        string FullName,
        string Email,
        string Password
        )
    {
    }
}
