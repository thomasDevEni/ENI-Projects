using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Contexts
{
    public class SortieContext: DbContext
    {
        public DbSet<Sortie> Sortie { get; set; }

        public SortieContext(DbContextOptions<SortieContext> options) : base(options)
        {
        }
    }
}
