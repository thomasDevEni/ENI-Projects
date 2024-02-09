﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TpDojo.Data;

#nullable disable

namespace TpDojo.Migrations
{
    [DbContext(typeof(TpDojoContext))]
    [Migration("20240110074206_addNoWeapon")]
    partial class addNoWeapon
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TpDojo.Models.Arme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Degats")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Arme");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nom = "Aucune Arme"
                        });
                });

            modelBuilder.Entity("TpDojo.Models.Samourai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ArmeId")
                        .HasColumnType("int");

                    b.Property<int?>("Force")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArmeId");

                    b.ToTable("Samourai");
                });

            modelBuilder.Entity("TpDojo.Models.Samourai", b =>
                {
                    b.HasOne("TpDojo.Models.Arme", "Arme")
                        .WithMany()
                        .HasForeignKey("ArmeId");

                    b.Navigation("Arme");
                });
#pragma warning restore 612, 618
        }
    }
}
