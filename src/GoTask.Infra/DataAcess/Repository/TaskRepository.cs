using GoTask.Domain.Data.Interface;
using GoTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoTask.Infra.DataAcess.Repository;

internal class TaskRepository(GoTaskDbContext dbContext) : ITaskRepository
{
    private readonly GoTaskDbContext _dbContext = dbContext;

    public async Task<IEnumerable<Tasks>> GetAllAsync(User user)
    {
        return await _dbContext.Tasks
            .AsNoTracking()
            .Where(t => t.User.UserIdentify == user.UserIdentify)
            .ToListAsync();
    }

    public async Task CreateTaskAsync(Tasks task)
    {
        await _dbContext.Tasks.AddAsync(task);
    }

    public async Task<Tasks?> GetAsync(string requestTitle)
    {
        return await _dbContext.Tasks
            .FirstOrDefaultAsync(t => EF.Functions.Like(t.Title, requestTitle));
    }
}