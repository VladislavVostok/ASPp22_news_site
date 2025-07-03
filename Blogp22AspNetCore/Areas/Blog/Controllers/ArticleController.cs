using Blogp22AspNetCore.Areas.Blog.Models.Settings;
using Blogp22AspNetCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogp22AspNetCore.Areas.Blog.Controllers
{
    public class ArticleController : Controller
    {

        private readonly BlogDBContext _context;
        private readonly IArticleRepository _articleRepository;

        public ArticleController(BlogDBContext context, IArticleRepository articleRepository)
        {
            _context = context;
            _articleRepository = articleRepository;
        }

        [HttpGet]
        //[Authorize]
		[Route("{area}/{controller}/{action}")]
		public async Task<ActionResult> Index()
        {
            var articles = await _articleRepository.GetAllArticlesAsync();
            return View(articles);
        }


		[HttpGet("{id}")]
		[Route("{area}/{controller}/{action}")]
		public async Task<ActionResult> Details(int id)
		{
			var article = await _articleRepository.GetArticleByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            
            return View(article);
		}

        [HttpGet("{slug}")]
        [Route("{area}/{controller}/{action}")]
        public async Task<ActionResult> DetailsBySlug(string slug)
        {
            var article = await _articleRepository.GetArticleBySlugAsync(slug);
            if (article == null)
            {
                return NotFound();
            }

            return View("Details",article);
        }

        [Authorize]
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

    }
}
