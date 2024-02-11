using Application.Dto;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using SortieApp.Infrastructure;
using AutoMapper;
using Application;

namespace SortieApp.Application
{
    public static class ApplicationService
    {
        public static IServiceCollection ConfigureApplicationService(this IServiceCollection services)
        {
            //Type et durée de vie su service (Type Singleton: unique et utilisé dans toute l'application)
            // Add AutoMapper and mapping profile
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IEtatService, EtatService>();
            services.AddScoped<ISortieService,SortieService> ();
            //services.AddScoped<RoleService> ();
            
           return services;
        }

    }
}