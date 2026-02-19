using GoTask.Domain.Data.Interface;
using GoTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoTask.Infra.DataAcess.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly GoTaskDbContext _dbContext;
        public UserRepository(GoTaskDbContext dbContext) => _dbContext = dbContext;

        public async Task<bool> ExistsUserWithEmail(string email)
        {
            return await _dbContext.User.AnyAsync(x => x.Email.Equals(email));
        }

        public async Task<User> Post(User user)
        {
            var userAdd = await _dbContext.User.AddAsync(user);
            return userAdd.Entity;
        }
    }
}
