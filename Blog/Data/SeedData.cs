using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog {
    public static class SeedData {
        public static void Initialize(IServiceProvider serviceProvider) {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>())) {
                if (context.Authors.Any() || context.Categories.Any() || context.BlogPosts.Any())
                    return;

                // Author examples
                var authors = new List<Author>
                {
                    new Author { Name = "Ahmet Yılmaz" },
                    new Author { Name = "Elif Kaya" }
                };
                context.Authors.AddRange(authors);
                context.SaveChanges();

                // Category examples
                var categories = new List<Category>
                {
                    new Category { Name = "Teknoloji" },
                    new Category { Name = "Tarih" }
                };
                context.Categories.AddRange(categories);
                context.SaveChanges();

                // BlogPost examples
                var blogPosts = new List<BlogPost>
                {
                    new BlogPost
                    {
                        Title = "İlk Blog Yazım",
                        Summary = "Bu benim ilk blog yazımın özeti.",
                        Content = "Bu bir test yazısıdır.",
                        AuthorId = authors[0].Id,
                        CategoryId = categories[0].Id,
                        CreatedAt = DateTime.Now
                    },
                    new BlogPost
                    {
                        Title = "Tarihte Bugün",
                        Summary = "Geçmişte bugün olan olaylar...",
                        Content = "Tarih hakkında ilginç bilgiler.",
                        AuthorId = authors[1].Id,
                        CategoryId = categories[1].Id,
                        CreatedAt = DateTime.Now
                    }
                };
                context.BlogPosts.AddRange(blogPosts);
                context.SaveChanges();
            }
        }
    }
}
