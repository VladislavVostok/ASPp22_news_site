using Microsoft.EntityFrameworkCore;
using Blogp22AspNetCore.Areas.Blog.Models.BlogModels;

namespace Blogp22AspNetCore.Areas.Blog.Models.Settings
{
    public class BlogDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }


        public BlogDBContext(DbContextOptions<BlogDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Article>()
                .HasOne(a => a.Author)
                .WithMany(u => u.Articles)
                .HasForeignKey(a => a.AuthorId);


            modelBuilder.Entity<ArticleTag>()
                .HasKey(at => new { at.ArticleId, at.TagId });


            modelBuilder.Entity<ArticleTag>()
                .HasOne(at => at.Article)
                .WithMany(a => a.ArticlesTags)
                .HasForeignKey(at => at.ArticleId);

            modelBuilder.Entity<ArticleTag>()
            .HasOne(at => at.Tag)
            .WithMany(t => t.ArticleTags)
            .HasForeignKey(at => at.TagId);

            modelBuilder.Entity<MenuItem>()
                .HasOne(m => m.Parent)
                .WithMany(m => m.Children)
                .HasForeignKey(m => m.ParentId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }
    }
}
