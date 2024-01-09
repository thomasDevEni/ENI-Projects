using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DemoEntityFrameWork
{
    public class AppContext: DbContext
    {
        public DbSet<Personne> Personnes { get; set; }

        public DbSet<Adresse> Adresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies(); 
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DemoEntityFrameWorkDb;MultipleActiveResultSets=true"); 
        }
    }
}
