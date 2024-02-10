using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SortieApp.Infrastructure
{
    public static class InfrastructureService
    {
        
            public static IServiceCollection ConfigureInfrastructureService(this IServiceCollection services)
            {
            //Type et durée de vie su service (Type Singleton: unique et utilisé dans toute l'application)
            services.AddScoped<ISortieRepository, SortieRepository>();
            services.AddDbContext<SortieContext>(options => options.UseSqlServer("Data Source=48SE46-HL5HHZ3;Initial Catalog=Sortie;User ID=sa;Password=Pa$$w0rd;Trust Server Certificate=True"));

            //services.AddSingleton<SortieRepository>();
            //services.AddSingleton<SortieContext>();
          

            return services;
            }

        
    }
}
