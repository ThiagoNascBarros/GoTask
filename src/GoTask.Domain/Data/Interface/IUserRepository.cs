using GoTask.Domain.Entities;

namespace GoTask.Domain.Data.Interface
{
    public interface IUserRepository
    {
        System.Threading.Tasks.Task Post(User user);
    }
}
