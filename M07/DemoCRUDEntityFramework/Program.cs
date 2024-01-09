using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DemoCRUDEntityFramework.Data;
namespace DemoCRUDEntityFramework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DemoCRUDEntityFrameworkContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DemoCRUDEntityFrameworkContext") ?? throw new InvalidOperationException("Connection string 'DemoCRUDEntityFrameworkContext' not found.")));

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