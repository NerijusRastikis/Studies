using DatabaseSeed.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSeed
{
    public class BookContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CSharpMokymaiDataSeed_books;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasData(CsvHelperService.GetBooks());
            modelBuilder.Entity<Author>()
                .HasData(CsvHelperService.GetAuthors());
            modelBuilder.Entity<Country>()
                .HasData(CsvHelperService.GetCountries());
            modelBuilder.Entity<Genre>()
                .HasData(CsvHelperService.GetGenres());
            modelBuilder.Entity<Publisher>()
                .HasData(CsvHelperService.GetPublishers());
        }
    }
}
