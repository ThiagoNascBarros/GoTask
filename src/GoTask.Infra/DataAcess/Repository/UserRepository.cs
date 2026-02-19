using GoTask.Domain.Data.Interface;
using GoTask.Domain.Entities;

namespace GoTask.Infra.DataAcess.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly GoTaskDbContext _dbContext;
        public UserRepository(GoTaskDbContext dbContext) => _dbContext = dbContext;

        public async Task<User> Post(User user)
        {
            var userAdd = await _dbContext.User.AddAsync(user);
            return userAdd.Entity;
        }
    }
}
