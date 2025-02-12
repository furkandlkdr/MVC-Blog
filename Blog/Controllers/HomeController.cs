using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.Data;

namespace Blog.Controllers {
    public class HomeController : Controller {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context) {
            _context = context;
        }

        public IActionResult Index() {
            var posts = _context.BlogPosts
                .Include(p => p.Author)
                .Include(p => p.Category)
                .ToList();
            return View(posts);
        }
    }
}
