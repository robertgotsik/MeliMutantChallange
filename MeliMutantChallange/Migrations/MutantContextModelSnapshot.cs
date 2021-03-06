﻿// <auto-generated />
using System;
using MeliMutantChallange;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeliMutantChallange.Migrations
{
    [DbContext(typeof(MutantContext))]
    partial class MutantContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MeliMutantChallange.Models.Adn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("dnaPersisted")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short?>("type")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Adn");
                });
#pragma warning restore 612, 618
        }
    }
}
