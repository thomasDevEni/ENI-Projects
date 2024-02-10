using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FestivallWeb.Data;
namespace FestivallWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<FestivallWebContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("FestivallWebContext") ?? throw new InvalidOperationException("Connection string 'FestivallWebContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}