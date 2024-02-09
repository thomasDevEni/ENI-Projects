using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace SortieApp.Application
{
    public static class ApplicationService
    {
        public static IServiceCollection ConfigureApplicationService(this IServiceCollection services)
        {
            //Type et durée de vie su service (Type Singleton: unique et utilisé dans toute l'application)
            services.AddSingleton<SortieService> ();
            
           return services;
        }
    }
}