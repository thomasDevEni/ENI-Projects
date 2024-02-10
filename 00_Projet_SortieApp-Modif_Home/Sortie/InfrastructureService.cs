using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace SortieApp.Infrastructure
{
    public static class InfrastructureService
    {
        
            public static IServiceCollection ConfigureInfrastructureService(this IServiceCollection services)
            {

            // Add AutoMapper and mapping profile
            services.AddAutoMapper(typeof(InfrastructureService));
            //Type et durée de vie su service (Type Singleton: unique et utilisé dans toute l'application)
            services.AddScoped<ISortieRepository, SortieRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IEtatRepository, EtatRepository>();
            services.AddScoped<IParticipantRepository, ParticipantRepository>();
            services.AddScoped<ILieuRepository, LieuRepository>();
            services.AddScoped<IInscriptionRepository, InscriptionRepository>();
            services.AddDbContext<SortieContext>(options => options.UseSqlServer("Data Source=DESKTOP-J96TQVV;Initial Catalog=Sortie;User ID=sa;Password=Pa$$w0rd;Trust Server Certificate=True"));
            services.AddDbContext<RoleContext>(options => options.UseSqlServer("Data Source=DESKTOP-J96TQVV;Initial Catalog=Sortie;User ID=sa;Password=Pa$$w0rd;Trust Server Certificate=True"));
            services.AddDbContext<EtatContext>(options => options.UseSqlServer("Data Source=DESKTOP-J96TQVV;Initial Catalog=Sortie;User ID=sa;Password=Pa$$w0rd;Trust Server Certificate=True"));
            services.AddDbContext<ParticipantContext>(options => options.UseSqlServer("Data Source=DESKTOP-J96TQVV;Initial Catalog=Sortie;User ID=sa;Password=Pa$$w0rd;Trust Server Certificate=True"));
            services.AddDbContext<LieuContext>(options => options.UseSqlServer("Data Source=DESKTOP-J96TQVV;Initial Catalog=Sortie;User ID=sa;Password=Pa$$w0rd;Trust Server Certificate=True"));
            services.AddDbContext<InscriptionContext>(options => options.UseSqlServer("Data Source=DESKTOP-J96TQVV;Initial Catalog=Sortie;User ID=sa;Password=Pa$$w0rd;Trust Server Certificate=True"));

            //services.AddSingleton<SortieRepository>();
            //services.AddSingleton<SortieContext>();


            return services;
            }

        
    }
}
