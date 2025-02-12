using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers {
    public class CategoryController : Controller {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context) {
            _context = context;
        }

        // List all categories
        public async Task<IActionResult> Index() {
            await _context.SaveChangesAsync();

            var categories = await _context.Categories.ToListAsync();
            return View(categories);
        }


        // Form to add a new category
        public IActionResult Create() {
            return View();
        }

        // Save new category to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category) {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Create", "Editor");
        }

        // Delete category
        public async Task<IActionResult> Delete(int id) {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
