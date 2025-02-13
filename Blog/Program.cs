using Blog.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Blog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using (var scope = app.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                try {
                    SeedData.Initialize(services);
                } catch (Exception ex) {
                    Console.WriteLine("Seed iþlemi sýrasýnda hata oluþtu: " + ex.Message);
                }
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "authorDetails",
                    pattern: "author/{id}",
                    defaults: new { controller = "Author", action = "Details" });

                endpoints.MapControllerRoute(
                    name: "categoryDetails",
                    pattern: "category/{id}",
                    defaults: new { controller = "Category", action = "Details" });

                endpoints.MapDefaultControllerRoute();
            });

            app.Run();
        }
    }
}
