using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FestivallWeb.Models;


namespace FestivallWeb.Data
{
    public class FestivallWebContext : DbContext
    {
        public FestivallWebContext (DbContextOptions<FestivallWebContext> options)
            : base(options)
        {
        }

        public DbSet<Artiste> Artiste { get; set; } = default!;

        public DbSet<Groupe> Groupe { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artiste>().HasData(new Artiste()
            {
                Id=1,
                Nom = "Mercury",
                Prenom = "Freddy",
                Instrument = "Piano",
                GroupeId = 1,

            });

            modelBuilder.Entity<Artiste>().HasData(new Artiste()
            {
                Id = 2,
                Nom = "Requier",
                Prenom = "Thomas",
                Instrument = "Guitare",
                
            });

            modelBuilder.Entity<Groupe>().HasData(new Groupe()
            {
                Id=1,
                Nom = "Queen",
                DateCreation= new DateTime(1977,11,24)

            });


        }
    }
}
