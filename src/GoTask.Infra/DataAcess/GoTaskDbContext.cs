using GoTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoTask.Infra.DataAcess
{
    internal class GoTaskDbContext : DbContext
    {
        public GoTaskDbContext(DbContextOptions<GoTaskDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}
