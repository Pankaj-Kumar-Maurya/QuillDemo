using Microsoft.AspNetCore.Mvc;
using QuillDemo.Data;
using QuillDemo.Models;
using System.Text.RegularExpressions;

namespace QuillDemo.Controllers
{
    public class PostController : Controller
    {
        private readonly AppDbContext _context;

        public PostController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Posts.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Posts.Add(post);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        public IActionResult Details(int id)
        {
            var post = _context.Posts.Find(id);
            return View(post);
        }
        public IActionResult Delete(int id)
        {
            var post = _context.Posts.FirstOrDefault(x => x.Id == id);

            if (post == null)
                return NotFound();

            // 1. Find all image src paths inside HTML
            var imgRegex = new Regex("<img[^>]+src=\"(?<url>[^\"]+)\"", RegexOptions.IgnoreCase);
            var matches = imgRegex.Matches(post.Content);

            foreach (Match match in matches)
            {
                var imageUrl = match.Groups["url"].Value;

                // Only delete local uploaded images
                if (imageUrl.StartsWith("/uploads/"))
                {
                    var imagePath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        imageUrl.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString())
                    );

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }
            }

            // 2. Remove post from database
            _context.Posts.Remove(post);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
