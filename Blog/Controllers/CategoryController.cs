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
            if (!ModelState.IsValid) {
                Console.WriteLine("ModelState geçerli değil!");
                foreach (var modelError in ModelState.Values.SelectMany(v => v.Errors)) {
                    Console.WriteLine(modelError.ErrorMessage);
                }
                return View(category);
            }

            Console.WriteLine("Category added");
            _context.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Delete category
        public async Task<IActionResult> Delete(int id) {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();

            _context.Categories.Remove(category);
            Console.WriteLine("Category deleted");
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
