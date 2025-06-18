using Microsoft.AspNetCore.Mvc;

namespace Blogp22AspNetCore.Areas.Blog.Controllers
{
    public class ContactController : Controller
    {

        [Route("{area}/{controller}/{action}")]
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
