using Application.Dto;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using SortieApp.Infrastructure;
using AutoMapper;

namespace SortieApp.Application
{
    public static class ApplicationService
    {
        public static IServiceCollection ConfigureApplicationService(this IServiceCollection services)
        {
            //Type et durée de vie su service (Type Singleton: unique et utilisé dans toute l'application)
            // Add AutoMapper and mapping profile
            //services.AddAutoMapper(typeof(ApplicationService));
            services.AddScoped<SortieService> ();
            //services.AddScoped<RoleService> ();
            
           return services;
        }

    }
}