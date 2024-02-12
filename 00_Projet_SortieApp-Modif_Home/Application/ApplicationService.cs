using Application.Dto;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using SortieApp.Infrastructure;
using AutoMapper;
using Application;
using FluentValidation;
using Application.Validators;

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
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IParticipantService, ParticipantService>();
            services.AddScoped<ILieuService, LieuService>();
            services.AddScoped<IInscriptionService, InscriptionService>();
            services.AddScoped<ISortieService,SortieService> ();
            // Register validators
            services.AddTransient<IValidator<RoleDto>, RoleValidator>();
            services.AddTransient<IValidator<EtatDto>, EtatValidator>();
            services.AddTransient<IValidator<ParticipantDto>, ParticipantValidator>();
            services.AddTransient<IValidator<InscriptionDto>, InscriptionValidator>();
            services.AddTransient<IValidator<SortieDto>, SortieValidator>();

            return services;
        }

    }
}