using GoTask.Domain.Entities;

namespace GoTask.Domain.Data.Interface;

public interface ITaskRepository
{
    Task<IEnumerable<Tasks>> GetAllAsync();
    Task CreateTaskAsync(Tasks task);
}