using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Contexts
{
    public class InscriptionContext : DbContext
    {
        public DbSet<Inscription> Inscription { get; set; }
        public InscriptionContext(DbContextOptions<InscriptionContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
            .Entity<Inscription>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

            base.OnModelCreating(modelBuilder);
        }
    }
}
