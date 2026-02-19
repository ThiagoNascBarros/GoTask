using GoTask.Domain.Entities;

namespace GoTask.Domain.Data.Interface
{
    public interface IUserRepository
    {
        Task<User> Post(User user);
    }
}
