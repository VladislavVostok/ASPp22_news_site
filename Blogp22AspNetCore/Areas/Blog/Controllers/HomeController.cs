using Blogp22AspNetCore.Areas.Blog.Models;
using Blogp22AspNetCore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blogp22AspNetCore.Areas.Blog.Controllers
{


    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleRepository _some;

        
        public HomeController(ILogger<HomeController> logger, IArticleRepository some)
        {
            _logger = logger;
            _some = some;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Danila()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
