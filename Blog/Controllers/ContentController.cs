using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.ViewModels;

namespace Blog.Controllers {
    public class ContentController : Controller {
        private readonly ApplicationDbContext _context;

        public ContentController(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IActionResult> AuthorsAndCategories() {
            var viewModel = new AuthorsCategoriesViewModel {
                Authors = await _context.Authors
                    .Include(a => a.BlogPosts)
                    .ToListAsync(),

                Categories = await _context.Categories
                    .Include(c => c.BlogPosts)
                    .ToListAsync()
            };

            return View(viewModel);
        }

    }
}
