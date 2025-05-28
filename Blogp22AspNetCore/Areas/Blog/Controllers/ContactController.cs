using Microsoft.AspNetCore.Mvc;

namespace Blogp22AspNetCore.Areas.Blog.Controllers
{
    public class ContactController : Controller
    {

        [Route("{area}/{action}")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
