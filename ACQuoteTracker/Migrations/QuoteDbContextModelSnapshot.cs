﻿// <auto-generated />
using ACQuoteTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ACQuoteTracker.Migrations
{
    [DbContext(typeof(QuoteDbContext))]
    partial class QuoteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("ACQuoteTracker.Models.Quote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("QuoteText")
                        .HasColumnType("TEXT");

                    b.Property<int>("VillagerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("VillagerId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("ACQuoteTracker.Models.Villager", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Villager");
                });

            modelBuilder.Entity("ACQuoteTracker.Models.Quote", b =>
                {
                    b.HasOne("ACQuoteTracker.Models.Villager", "Villager")
                        .WithMany()
                        .HasForeignKey("VillagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
