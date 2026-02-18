using GoTask.Domain.Data.Interface;
using GoTask.Domain.Entities;

namespace GoTask.Infra.DataAcess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly GoTaskDbContext _dbContext;
        public UserRepository(GoTaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async System.Threading.Tasks.Task Post(User user)
        {
            _dbContext.User.Add(user);
            _dbContext.SaveChanges();
        }
    }
}
