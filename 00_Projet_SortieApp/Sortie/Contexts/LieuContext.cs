using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Contexts
{
    public class LieuContext : DbContext
    {
        public DbSet<Lieu> Lieu { get; set; }
        public LieuContext(DbContextOptions<LieuContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
            .Entity<Lieu>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

            base.OnModelCreating(modelBuilder);
        }
    }
}
