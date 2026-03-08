using GoTask.Domain.Entities;

namespace GoTask.Domain.Data.Interface;

public interface ITaskRepository
{
    Task<IEnumerable<Tasks>> GetAllAsync(User user);
    Task CreateTaskAsync(Tasks task);
    Task<Tasks> GetAsync(string requestTitle);
}