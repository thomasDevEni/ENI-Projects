using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Contexts
{
    public class EtatContext : DbContext
    {
        public DbSet<Etat> Etat { get; set; }
        public EtatContext(DbContextOptions<EtatContext> options) : base(options)
        {
        }
    }
}
