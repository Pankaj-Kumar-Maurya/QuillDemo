using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuillDemo.Data;
using QuillDemo.Models;

namespace QuillDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        public HomeController(ILogger<HomeController> logger,AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var homePages = _context.Posts
         .Where(x => x.Slug == "home")
         .ToList();

            return View(homePages);
        }

        public IActionResult Privacy()
        {
            var privacyPage = _context.Posts.FirstOrDefault(x => x.Slug == "privacy");

            return View(privacyPage);
        }

        public IActionResult Test()
        {
            var testPage = _context.Posts.Where(T => T.Slug == "Test").ToList();
            return View(testPage);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
