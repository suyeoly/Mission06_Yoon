﻿using Microsoft.EntityFrameworkCore;

namespace Mission06_Yoon.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {
        }

        public DbSet<AddingMovie> Movies { get; set; }
        public DbSet<Categories> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasData(

                new Categories { CategoryId = 1, Category = "Miscellaneous" },
                new Categories { CategoryId = 2, Category = "Drama" },
                new Categories { CategoryId = 3, Category = "Television" },
                new Categories { CategoryId = 4, Category = "Horror/Suspense" },
                new Categories { CategoryId = 5, Category = "Comedy" },
                new Categories { CategoryId = 6, Category = "Family" },
                new Categories { CategoryId = 7, Category = "Action/Adventure" },
                new Categories { CategoryId = 8, Category = "VHS" }

                );
        }
    }
}
 