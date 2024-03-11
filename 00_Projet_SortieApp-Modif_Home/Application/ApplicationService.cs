using Application.Dto;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using SortieApp.Infrastructure;
using AutoMapper;
using Application;
using FluentValidation;
using Application.Validators;
using Microsoft.AspNetCore.Builder;

namespace SortieApp.Application
{
    public static class ApplicationService
    {
        public static IServiceCollection ConfigureApplicationService(this IServiceCollection services)
        {
            //Type et durée de vie su service (Type Singleton: unique et utilisé dans toute l'application)
            // Add AutoMapper and mapping profile
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IAuthentificationService, AuthentificationService>();
            services.AddScoped<IUtilisateurService, UtilisateurService>();
            services.AddScoped<IEtatService, EtatService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IParticipantService, ParticipantService>();
            services.AddScoped<ILieuService, LieuService>();
            services.AddScoped<IInscriptionService, InscriptionService>();
            services.AddScoped<ISortieService,SortieService> ();
            services.AddScoped<IJwtService, JwtService>();
            // Register validators
            services.AddTransient<IValidator<UtilisateurDto>, UtilisateurValidator>();
            services.AddTransient<IValidator<AuthentificationDto>, AuthentificationValidator>();
            services.AddTransient<IValidator<RoleDto>, RoleValidator>();
            services.AddTransient<IValidator<EtatDto>, EtatValidator>();
            services.AddTransient<IValidator<ParticipantDto>, ParticipantValidator>();
            services.AddTransient<IValidator<LieuDto>, LieuValidator>();
            services.AddTransient<IValidator<InscriptionDto>, InscriptionValidator>();
            services.AddTransient<IValidator<SortieDto>, SortieValidator>();

            return services;
        }

    }
}