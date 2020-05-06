using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reddit.Entities;

namespace Reddit.DBServis
{
    public class RedditDbContext : IdentityDbContext<UserReddit>
    {
        public RedditDbContext(DbContextOptions<RedditDbContext> options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Post> Opinions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
