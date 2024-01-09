using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TpDojo.Models;

namespace TpDojo.Data
{
    public class TpDojoContext : DbContext
    {
        public TpDojoContext (DbContextOptions<TpDojoContext> options)
            : base(options)
        {
        }

        public DbSet<TpDojo.Models.Arme> Arme { get; set; } = default!;

        public DbSet<TpDojo.Models.Samourai>? Samourai { get; set; }
    }
}
