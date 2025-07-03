using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Blogp22AspNetCore.Areas.Blog.Models.BlogModels
{
    public class Base
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }

    }

    public class AppUser : IdentityUser
    {
        public ICollection<Article> Articles { get; set; }
    }

    public class Article : Base
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
		[Required]
		public string Content { get; set; }
        public string CategotyMenu { get; set; }
        public bool IsPublished { get; set; }

		[Required]
		public string Slug { get; set; }
		public int UserId { get; set; }
        public AppUser User { get; set; }

        public ICollection<ArticleTag> ArticlesTags { get; set; }


    }

    public class Tag : Base {
		[Required]
        [StringLength(50)]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
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
		[Required]
        [StringLength(50)]
		public string Title { get; set; }
		[Required]
        [StringLength(50)]
		public string Url { get; set; }
        public int? ParentId { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; } = true;

        public MenuItem Parent { get; set; }

        public ICollection<MenuItem> Children { get; set; }


    }
}