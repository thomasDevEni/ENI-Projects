﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Contexts
{
    public class RoleContext : DbContext
    {
        public DbSet<Role> Role { get; set; }
        public RoleContext(DbContextOptions<SortieContext> options) : base(options)
        {
        }
    }
}