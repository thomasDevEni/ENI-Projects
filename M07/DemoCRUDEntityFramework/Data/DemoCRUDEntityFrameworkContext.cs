using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DemoCRUDEntityFramework.Models;

namespace DemoCRUDEntityFramework.Data
{
    public class DemoCRUDEntityFrameworkContext : DbContext
    {
        public DemoCRUDEntityFrameworkContext (DbContextOptions<DemoCRUDEntityFrameworkContext> options)
            : base(options)
        {
        }

        public DbSet<DemoCRUDEntityFramework.Models.Etudiant> Etudiant { get; set; } = default!;
    }
}
