using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;


namespace Plugins.DataStore.SQL
{
    public class Graf:DbContext
    {
        public Graf(DbContextOptions options):base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Movies)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", Description = "Action" },
                new Category { Id = 2, Name = "Adventure", Description = "Adventure" },
                new Category { Id = 3, Name = "Comedy", Description = "Comedy" },
                new Category { Id = 4, Name = "Drama", Description = "Drama" },
                new Category { Id = 5, Name = "Crime", Description = "Crime" }

                );
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, CategoryId = 1, DirectorName = "John Samuel", MovieName = "Evil Camp", MovieImdb = "3.2", ReleaseYear = "2000" },
                new Movie { Id = 2, CategoryId = 2, DirectorName = "John Simul", MovieName = "İmage Camp", MovieImdb = "7.2", ReleaseYear = "1980" },
                new Movie { Id = 3, CategoryId = 3, DirectorName = "John Luel", MovieName = "Devil Camp", MovieImdb = "2.2", ReleaseYear = "2003" }
                );
        }
    }
}
