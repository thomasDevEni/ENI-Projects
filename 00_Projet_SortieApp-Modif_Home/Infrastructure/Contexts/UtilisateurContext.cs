using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contexts
{
    public class UtilisateurContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateur { get; set; }
        public UtilisateurContext(DbContextOptions<UtilisateurContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
            .Entity<Utilisateur>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

            base.OnModelCreating(modelBuilder);
        }

    }
}
