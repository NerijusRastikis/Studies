using ManyToMany.Configuration;
using ManyToMany.Entities;
using ManyToMany.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany
{
    public class BookContext : DbContext
    {
        public static bool IsSeeding = true;
        public BookContext() : base()
        {
        }
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CSharpMokymaiMTM_books;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //sita konfiguracija nebutina, nes EF Core atpazista Many-to-Many ryšį ir be jos
            //modelBuilder.Entity<Book>()
            //    .HasMany(b => b.Categories)
            //    .WithMany(c => c.Books)
            //    .UsingEntity<Dictionary<string,object>>("BookCategory", 
            //        j => j.HasOne<Category>().WithMany().HasForeignKey("CategoryId"),
            //        j => j.HasOne<Book>().WithMany().HasForeignKey("BookId"));

            if (IsSeeding)
            {
                modelBuilder.Entity<Book>().HasData(CsvHelper.GetBooks());
                //modelBuilder.Entity<Book>().HasData(
                //    new Book { BookId = 1, Name = "Hobbit", Year = 1937 },
                //    new Book { BookId = 2, Name = "Lord of the Rings", Year = 1954 },
                //    new Book { BookId = 3, Name = "Silmarillion", Year = 1977 },
                //    new Book { BookId = 4, Name = "Hitchhiker's Guide to the Galaxy", Year = 1979 },
                //    new Book { BookId = 5, Name = "Dune", Year = 1965 },
                //    new Book { BookId = 6, Name = "Dune: House of Atreides", Year = 1999 },
                //    new Book { BookId = 7, Name = "Dune: The Butlerian Jihad", Year = 2002 }
                //);
                modelBuilder.Entity<Category>().HasData(CsvHelper.GetCategories());
                //modelBuilder.Entity<Category>().HasData(
                //    new Category { CategoryId = 1, Name = "Adventure" },
                //    new Category { CategoryId = 2, Name = "Science Fiction" },
                //    new Category { CategoryId = 3, Name = "Fantasy" }
                //);
                modelBuilder.Entity<Author>().HasData(CsvHelper.GetAuthors());
                modelBuilder.Entity<Author>()
                    .HasMany(a => a.Books)
                    .WithMany(d => d.Authors)
                    .UsingEntity(e => e.HasData(
                        new { BooksBookId = 1, AuthorsAuthorId =  1},
                        new { BooksBookId = 2, AuthorsAuthorId =  1},
                        new { BooksBookId = 3, AuthorsAuthorId =  1},
                        new { BooksBookId = 4, AuthorsAuthorId =  2},
                        new { BooksBookId = 5, AuthorsAuthorId =  3},
                        new { BooksBookId = 6, AuthorsAuthorId =  4},
                        new { BooksBookId = 6, AuthorsAuthorId =  5},
                        new { BooksBookId = 7, AuthorsAuthorId =  4},
                        new { BooksBookId = 7, AuthorsAuthorId =  5}
                        ));
                modelBuilder.Entity<Book>()
                    .HasMany(b => b.Categories)
                    .WithMany(c => c.Books)
                    .UsingEntity(j => j.HasData(
                        new { BooksBookId = 1, CategoriesCategoryId = 1 }, //Hobbit-to-Adventure
                        new { BooksBookId = 1, CategoriesCategoryId = 3 }, //Hobbit-to-Fantasy
                        new { BooksBookId = 2, CategoriesCategoryId = 1 }, //LordOfTheRings-to-Adventure
                        new { BooksBookId = 3, CategoriesCategoryId = 3 }, //Silmarillion-to-Fantasy
                        new { BooksBookId = 4, CategoriesCategoryId = 1 }, //Hitchhiker-to-Adventure
                        new { BooksBookId = 4, CategoriesCategoryId = 2 }, //Hitchhiker-to-Science Fiction
                        new { BooksBookId = 5, CategoriesCategoryId = 2 }, //Dune-to-Science Fiction
                        new { BooksBookId = 6, CategoriesCategoryId = 2 }, //DuneHouseOfAtreides-to-Science Fiction
                        new { BooksBookId = 7, CategoriesCategoryId = 2 }  //DuneTheButlerianJihad-to-Science Fiction
                    ));
                modelBuilder.Entity<Chapter>().HasData(CsvHelper.GetChapters());
                modelBuilder.Entity<Chapter>()
                    .HasOne(c => c.Book)
                    .WithMany(b => b.Chapters)
                    .HasForeignKey(c => c.BookId);

                modelBuilder.ApplyConfiguration(new BookConfiguration());
                modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            }
        }
    }
}
