using GoTask.Domain.Entities;

namespace GoTask.Domain.Security.Token;

public interface IAuthDecode
{
    Task<User> DecodeTokenToUser();
}