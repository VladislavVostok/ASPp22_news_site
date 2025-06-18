using Blogp22AspNetCore.Areas.Blog.Models.BlogModels;
using Blogp22AspNetCore.Areas.Blog.Models.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogp22AspNetCore.Areas.Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : Controller
    {

        private readonly BlogDBContext _context;

        public BlogController(BlogDBContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
        {

            var articles = await _context.Articles
                .Include(a => a.Author)
                .Include(a => a.ArticlesTags)
                .ThenInclude(at => at.Tag)
                .OrderByDescending(a => a.CreateAt)
                .ToListAsync();

            var articlesDTO = new
            {
                articles = articles
            };

            return View(articlesDTO);
        }





        //[Route("{area}/{action}")]
        //[HttpGet]
        //public IActionResult Detail()
        //{
        //    return View();
        //}
    }
}
