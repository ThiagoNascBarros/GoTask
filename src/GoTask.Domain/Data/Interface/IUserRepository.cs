using GoTask.Domain.Entities;

namespace GoTask.Domain.Data.Interface
{
    public interface IUserRepository
    {
        Task Post(User user);
    }
}
