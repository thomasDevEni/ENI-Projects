using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace SortieApp.Infrastructure
{
    public static class InfrastructureService
    {
        
            public static IServiceCollection ConfigureInfrastructureService(this IServiceCollection services)
            {
                //Type et durée de vie su service (Type Singleton: unique et utilisé dans toute l'application)
                services.AddDbContext<SortieContext>();
                services.AddScoped<SortieRepository>();
                //services.AddSingleton<SortieRepository>();
                //services.AddSingleton<SortieContext>();

            return services;
            }

        
    }
}
