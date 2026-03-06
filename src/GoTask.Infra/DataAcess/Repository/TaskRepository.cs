using GoTask.Domain.Data.Interface;
using GoTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoTask.Infra.DataAcess.Repository;

internal class TaskRepository(GoTaskDbContext dbContext) : ITaskRepository
{
    private readonly GoTaskDbContext _dbContext = dbContext;

    public async Task<IEnumerable<Tasks>> GetAllAsync()
    {
        return await _dbContext.Tasks.ToListAsync();
    }

    public async Task CreateTaskAsync(Tasks task)
    {
        await _dbContext.Tasks.AddAsync(task);
    }
}