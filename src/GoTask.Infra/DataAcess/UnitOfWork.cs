using GoTask.Domain.Data.Interface;

namespace GoTask.Infra.DataAcess
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly GoTaskDbContext _dbContext;

        public UnitOfWork(GoTaskDbContext dbContext) => this._dbContext = dbContext;

        public async Task Commit() => await _dbContext.SaveChangesAsync();
    }
}
