using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.Models;

namespace Blog.Controllers {
    public class EditorController : Controller {
        private readonly ApplicationDbContext _context;

        public EditorController(ApplicationDbContext context) {
            _context = context;
        }

        // Route to /Editor/Create
        public IActionResult Index() {
            return RedirectToAction("Create");
        }

        // When page opens
        public IActionResult Create() {
            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name");
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // When form is submitted
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BlogPost post, int AuthorId, int CategoryId) {
            // Manually set the Author and Category properties because the form does not post them
            // If the AuthorId or CategoryId is invalid, add a model error
            post.Author = _context.Authors.Find(AuthorId);
            if (post.Author == null) {
                ModelState.AddModelError(nameof(AuthorId), "Could not find the selected author.");
            }

            post.Category = _context.Categories.Find(CategoryId);
            if (post.Category == null) {
                ModelState.AddModelError(nameof(CategoryId), "Could not find the selected category.");
            }

            post.CreatedAt = DateTime.Now;

            if (ModelState.IsValid) {
                _context.BlogPosts.Add(post);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name");
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ClearDatabase() {
            _context.ClearDatabase();
            return RedirectToAction("Index", "Home");
        }
    }
}
