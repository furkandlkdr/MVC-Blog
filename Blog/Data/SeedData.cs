using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Blog {
    public static class SeedData {
        public static void Initialize(IServiceProvider serviceProvider) {
            using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>())) {
                if (context.BlogPosts.Any()) return;

                // Author and category examples
                var author1 = new Author { Name = "Furkan" };
                var author2 = new Author { Name = "Ahmet" };

                var category1 = new Category { Name = "Teknoloji" };
                var category2 = new Category { Name = "Yazılım" };

                context.Authors.AddRange(author1, author2);
                context.Categories.AddRange(category1, category2);
                context.SaveChanges();

                // Blog post examples
                var blog1 = new BlogPost {
                    Title = "ASP.NET Core ile MVC Geliştirme",
                    Summary = "Bu yazıda ASP.NET Core ile MVC'nin temel yapılarını anlatıyoruz.",
                    Content = "Detaylı içerik burada...",
                    AuthorId = author1.Id,
                    CategoryId = category1.Id,
                    CreatedAt = DateTime.Now
                };

                var blog2 = new BlogPost {
                    Title = "C# ile Design Patterns",
                    Summary = "Bu yazıda C# programlama dilinde design pattern örnekleri anlatılmaktadır.",
                    Content = "Detaylı içerik burada...",
                    AuthorId = author2.Id,
                    CategoryId = category2.Id,
                    CreatedAt = DateTime.Now
                };

                context.BlogPosts.AddRange(blog1, blog2);
                context.SaveChanges();
            }
        }
    }
}
