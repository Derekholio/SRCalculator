﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SRCalculator.SQLite;

namespace SRCalculator.Migrations
{
    [DbContext(typeof(SRCalculatorContext))]
    [Migration("20190228003753_RankImage")]
    partial class RankImage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085");

            modelBuilder.Entity("SRCalculator.SQLite.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("PrivateProfile");

                    b.Property<string>("RankImage");

                    b.Property<int>("SR");

                    b.Property<string>("Username");

                    b.HasKey("ID");

                    b.ToTable("Players");
                });
#pragma warning restore 612, 618
        }
    }
}