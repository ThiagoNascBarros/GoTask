using GoTask.Domain.Data.Interface;
using GoTask.Domain.Entities;

namespace GoTask.Infra.DataAcess.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly GoTaskDbContext _dbContext;
        public UserRepository(GoTaskDbContext dbContext) => _dbContext = dbContext;

        public async Task Post(User user)
        {
            _dbContext.User.Add(user);
        }
    }
}
