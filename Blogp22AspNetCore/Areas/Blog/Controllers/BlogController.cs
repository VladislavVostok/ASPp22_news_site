using Microsoft.AspNetCore.Mvc;

namespace Blogp22AspNetCore.Areas.Blog.Controllers
{
    public class BlogController : Controller
    {
        [Route("{area}/{action}")]
        [HttpGet]
        public IActionResult Detail()
        {
            return View();
        }
    }
}
