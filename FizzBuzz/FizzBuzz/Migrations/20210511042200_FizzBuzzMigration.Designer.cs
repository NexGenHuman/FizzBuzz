﻿// <auto-generated />
using System;
using FizzBuzz.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FizzBuzz.Migrations
{
    [DbContext(typeof(FizzBuzzContext))]
    [Migration("20210511042200_FizzBuzzMigration")]
    partial class FizzBuzzMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FizzBuzz.Models.FizzBuzz_Data", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("date");

                    b.Property<int>("input");

                    b.Property<string>("output");

                    b.HasKey("id");

                    b.ToTable("fizzBuzz_Data");
                });
#pragma warning restore 612, 618
        }
    }
}
