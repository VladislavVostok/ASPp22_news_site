
using Blogp22AspNetCore.Areas.Blog.Models.BlogModels;
using Blogp22AspNetCore.Areas.Blog.Models.Settings;
using Microsoft.EntityFrameworkCore;

namespace Blogp22AspNetCore.Services
{
	public class ArticleRepository : IArticleRepository
	{
		private readonly BlogDBContext _ctx;

		public ArticleRepository(BlogDBContext context)
		{
			_ctx = context;
		}

		public async Task<IEnumerable<Article>> GetAllArticlesAsync()
		{
			return await _ctx.Articles
				.Include(a => a.User)
				.Include(a => a.ArticlesTags)
				.ThenInclude(at => at.Tag)
				.OrderByDescending(a => a.CreateAt)
				.ToListAsync();
		}

		public async Task<Article> GetArticleByIdAsync(int id)
		{
			return await _ctx.Articles
				.Include(a => a.User)
				.Include(a => a.ArticlesTags)
				.ThenInclude(at => at.Tag)
				.FirstOrDefaultAsync(a => a.Id == id);
		}

		public async Task<Article> GetArticleBySlugAsync(string slug)
		{
			return await _ctx.Articles
				.Include(a => a.User)
				.Include(a => a.ArticlesTags)
				.ThenInclude(at => at.Tag)
				.FirstOrDefaultAsync(a => a.Slug == slug);
		}

		public async Task<IEnumerable<Article>> GetArticlesByTagAsync(string tagSlug)
		{
			return await _ctx.Articles
				.Where(a => a.ArticlesTags.Any(at => at.Tag.Slug == tagSlug))
				.Include(a => a.User)
				.Include(a => a.ArticlesTags)
				.ThenInclude(at => at.Tag)
				.OrderByDescending(a => a.CreateAt)
				.ToListAsync();
		}

		public async Task UpdateArticleAsync(Article article)
		{
			_ctx.Articles.Update(article);
			await _ctx.SaveChangesAsync();
		}

		public async Task AddArticleAsync(Article article)
		{
			await _ctx.Articles.AddAsync(article);
			await _ctx.SaveChangesAsync(); 
		}

		public async Task DeleteArticleAsync(int id)
		{
			var article = await GetArticleByIdAsync(id);
			if(article != null)
			{
				_ctx.Articles.Remove(article);
				await _ctx.SaveChangesAsync();
			}

		}
	}
}
