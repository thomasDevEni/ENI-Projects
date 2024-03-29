﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Contexts
{
    public class ParticipantContext : DbContext
    {
        public DbSet<Participant> Participant { get; set; }
        
        public ParticipantContext(DbContextOptions<ParticipantContext> options) : base(options)
        {
        }

        //AutoIncrementation des Id's Participant & Mail
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
            .Entity<Participant>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();


            base.OnModelCreating(modelBuilder);
        }
    }
}