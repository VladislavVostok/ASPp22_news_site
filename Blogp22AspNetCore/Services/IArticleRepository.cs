using Blogp22AspNetCore.Areas.Blog.Models.BlogModels;

namespace Blogp22AspNetCore.Services
{
	public interface IArticleRepository
	{
		Task<IEnumerable<Article>> GetAllArticlesAsync();
		Task<Article> GetArticleByIdAsync(int id);
		Task<Article> GetArticleBySlugAsync(string slug);
		Task<IEnumerable<Article>> GetArticlesByTagAsync(string tagSlug);
		Task AddArticleAsync(Article article);
		Task DeleteArticleAsync(int id);
		Task UpdateArticleAsync(Article article);

	}
}
