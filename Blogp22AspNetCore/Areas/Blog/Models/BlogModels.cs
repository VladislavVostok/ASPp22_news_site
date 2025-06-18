using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blogp22AspNetCore.Areas.Blog.Models.BlogModels
{


    public class Base
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }

    }

    public class User : Base
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? LastLogin { get; set; }
        public ICollection<Article> Articles { get; set; }

    }

    public class Article : Base
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string CategotyMenu { get; set; }
        public bool IsPublished { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }

        public ICollection<ArticleTag> ArticlesTags { get; set; }


    }

    public class Tag : Base {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }

        public ICollection<ArticleTag> ArticleTags { get; set; }

    }

    public class ArticleTag {
        public int ArticleId { get; set; }
        public Article Article { get; set; }


        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }

    public class MenuItem : Base
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int? ParentId { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; } = true;

        public MenuItem Parent { get; set; }

        public ICollection<MenuItem> Children { get; set; }


    }
}