using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Xml;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Contexts
{
    public class EtatContext : DbContext
    {
        public DbSet<Etat> Etat { get; set; }
        public EtatContext(DbContextOptions<EtatContext> options) : base(options)
        {
        }

              

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder
            .Entity<Etat>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

            base.OnModelCreating(modelBuilder);
        }
    }
}
