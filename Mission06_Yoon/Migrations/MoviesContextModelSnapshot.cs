﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mission06_Yoon.Models;

#nullable disable

namespace Mission06_Yoon.Migrations
{
    [DbContext(typeof(MoviesContext))]
    partial class MoviesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Mission06_Yoon.Models.AddingMovie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CopiedToPlex")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Director")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LentTo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<string>("Rating")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Year")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Mission06_Yoon.Models.Categories", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Category = "Miscellaneous"
                        },
                        new
                        {
                            CategoryId = 2,
                            Category = "Drama"
                        },
                        new
                        {
                            CategoryId = 3,
                            Category = "Television"
                        },
                        new
                        {
                            CategoryId = 4,
                            Category = "Horror/Suspense"
                        },
                        new
                        {
                            CategoryId = 5,
                            Category = "Comedy"
                        },
                        new
                        {
                            CategoryId = 6,
                            Category = "Family"
                        },
                        new
                        {
                            CategoryId = 7,
                            Category = "Action/Adventure"
                        },
                        new
                        {
                            CategoryId = 8,
                            Category = "VHS"
                        });
                });

            modelBuilder.Entity("Mission06_Yoon.Models.AddingMovie", b =>
                {
                    b.HasOne("Mission06_Yoon.Models.Categories", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}