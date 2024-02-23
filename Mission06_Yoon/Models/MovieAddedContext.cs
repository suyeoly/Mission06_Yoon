using Microsoft.EntityFrameworkCore;

namespace Mission06_Yoon.Models
{
    public class MovieAddedContext : DbContext
    {
        public MovieAddedContext(DbContextOptions<MovieAddedContext> options) : base(options)
        {
        }

        public DbSet<AddingMovie> MoviesAdded { get; set; }
        public DbSet<Categories> CategoryTable { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasData(

                new Categories { CategoryId = 1, Category = "Miscellaneous" },
                new Categories { CategoryId = 2, Category = "Drama" },
                new Categories { CategoryId = 3, Category = "Magic" },
                new Categories { CategoryId = 4, Category = "Television" },
                new Categories { CategoryId = 5, Category = "Horror/Suspense" },
                new Categories { CategoryId = 6, Category = "Comedy" },
                new Categories { CategoryId = 7, Category = "Family" },
                new Categories { CategoryId = 8, Category = "Action/Adventure" },
                new Categories { CategoryId = 9, Category = "VHS" }

                );
        }
    }
}
 