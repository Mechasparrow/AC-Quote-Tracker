﻿// <auto-generated />
using ACQuoteTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ACQuoteTracker.Migrations
{
    [DbContext(typeof(QuoteTrackerDbContext))]
    [Migration("20200614225334_FirstMigrations")]
    partial class FirstMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("ACQuoteTracker.Models.Quote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("QuoteText")
                        .HasColumnType("TEXT");

                    b.Property<int>("VillagerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("QuoteId");

                    b.HasIndex("VillagerId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("ACQuoteTracker.Models.Villager", b =>
                {
                    b.Property<int>("VillagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.HasKey("VillagerId");

                    b.ToTable("Villagers");
                });

            modelBuilder.Entity("ACQuoteTracker.Models.Quote", b =>
                {
                    b.HasOne("ACQuoteTracker.Models.Villager", "Villager")
                        .WithMany("Quotes")
                        .HasForeignKey("VillagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
