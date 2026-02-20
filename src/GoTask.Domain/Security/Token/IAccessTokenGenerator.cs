using GoTask.Domain.Entities;

namespace GoTask.Domain.Security.Token
{
    public interface IAccessTokenGenerator
    {
        string Generate(User user);
    }
}
