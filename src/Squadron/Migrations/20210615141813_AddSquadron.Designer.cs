﻿// <auto-generated />
using Armory.Squadron.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Armory.Squadron.Migrations
{
    [DbContext(typeof(SquadronDbContext))]
    [Migration("20210615141813_AddSquadron")]
    partial class AddSquadron
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("Armory.Squadron.Domain.Squadron", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ArmoryUserId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Code");

                    b.ToTable("Squadrons");
                });
#pragma warning restore 612, 618
        }
    }
}