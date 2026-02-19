using GoTask.Domain.Entities;

namespace GoTask.Domain.Data.Interface
{
    public interface IUserRepository
    {
        Task<User> Post(User user);
        Task<bool> ExistsUserWithEmail(string email);
    }
}
