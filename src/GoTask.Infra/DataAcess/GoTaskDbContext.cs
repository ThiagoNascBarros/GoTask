using GoTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoTask.Infra.DataAcess
{
    public class GoTaskDbContext : DbContext
    {
        public GoTaskDbContext(DbContextOptions<GoTaskDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Domain.Entities.Task> Tasks { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}
