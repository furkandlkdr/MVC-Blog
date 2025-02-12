using Microsoft.EntityFrameworkCore;
using Blog.Models;

namespace Blog.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        // Clear the database method for test purposes
        public void ClearDatabase() {
            BlogPosts.RemoveRange(BlogPosts);
            Authors.RemoveRange(Authors);
            Categories.RemoveRange(Categories);
            SaveChanges();
        }
    }
}
