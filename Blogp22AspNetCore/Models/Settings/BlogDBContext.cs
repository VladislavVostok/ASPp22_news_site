using Microsoft.EntityFrameworkCore;

namespace Blogp22AspNetCore.Models.Settings
{
    public class BlogDBContext: DbContext
    {
        public DbSet<CntrEm133> CntrEm133s { get; set; }

        public BlogDBContext(DbContextOptions<BlogDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
