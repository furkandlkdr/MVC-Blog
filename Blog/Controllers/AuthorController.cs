using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers {
    public class AuthorController : Controller {
        private readonly ApplicationDbContext _context;

        public AuthorController(ApplicationDbContext context) {
            _context = context;
        }
        // List all authors
        public async Task<IActionResult> Index() {
            var authors = await _context.Authors.ToListAsync();
            return View(authors);
        }

        // Form to create a new author
        public IActionResult Create() {
            return View();
        }

        // Save new author to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author author) {
            if (ModelState.IsValid) {
                _context.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // Delete author
        public async Task<IActionResult> Delete(int id) {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return NotFound();

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
