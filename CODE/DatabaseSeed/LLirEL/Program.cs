using LLirEL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LLirEL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Loading!");

            using var context = new BookContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            FillDatabase(context);
            GetBooks();
            GetBooks_Include();

        }

        static void GetBooks()
        {
            using var context = new BookContext();
            var books = context.Books.ToList();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Eager Loading (without Include)");
            Console.WriteLine("Books count: " + books.Count());
            foreach (var book in books)
            {
                Console.WriteLine($"Book: '{book.Title}', Authors count: '{book.Authors?.Count}', Genre: '{book.Genre?.Name}', Publisher: '{book.Publisher?.Name}' ");
                foreach (var author in book.Authors)
                {
                    Console.WriteLine($"  -> Author: '{author.FullName}', Country: '{author.Country?.Name}'");
                }
            }
        }

        static void GetBooks_Include()
        {
            using var context = new BookContext();
            var books = context.Books.Include(x => x.Authors).ToList();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Eager Loading (Include)");
            Console.WriteLine("Books count: " + books.Count());
            foreach (var book in books)
            {
                Console.WriteLine($"Book: '{book.Title}', Authors count: '{book.Authors?.Count}', Genre: '{book.Genre?.Name}', Publisher: '{book.Publisher?.Name}' ");
                foreach (var author in book.Authors)
                {
                    Console.WriteLine($"  -> Author: '{author.FullName}', Country: '{author.Country?.Name}'");
                }
            }
        }














        private static void FillDatabase(BookContext context)
        {
            //add some publishers
            var harperCollins = new Publisher { Name = "HarperCollins" };
            var georgeAllenUnwin = new Publisher { Name = "George Allen & Unwin" };
            var hodderAndStoughton = new Publisher { Name = "Hodder & Stoughton" };
            var chiltonBooks = new Publisher { Name = "Chilton Books" };
            var bantamSpectra = new Publisher { Name = "Bantam Spectra" };
            context.Publishers.AddRange(harperCollins, georgeAllenUnwin, hodderAndStoughton, chiltonBooks, bantamSpectra);
            context.SaveChanges();

            //add some genres
            var fantasy = new Genre { Name = "Fantasy" };
            var scienceFiction = new Genre { Name = "Science Fiction" };
            context.Genres.AddRange(fantasy, scienceFiction);
            context.SaveChanges();

            //add some countries
            var uk = new Country { Name = "United Kingdom" };
            var usa = new Country { Name = "United States of America" };
            context.Countries.AddRange(uk, usa);
            context.SaveChanges();

            //add some authors
            var tolkien = new Author { FullName = "J.R.R. Tolkien", Country = uk };
            var adams = new Author { FullName = "Douglas Adams", Country = uk };
            var herbert = new Author { FullName = "Frank Herbert", Country = usa };
            var anderson = new Author { FullName = "Kevin J. Anderson", Country = usa };
            context.Authors.AddRange(tolkien, adams, herbert, anderson);
            context.SaveChanges();

            //add some books
            var hobbit = new Book
            {
                Title = "The Hobbit",
                Year = 1937,
                Authors = new List<Author> { tolkien },
                Publisher = georgeAllenUnwin,
                Genre = fantasy
            };
            var lordOfTheRings = new Book
            {
                Title = "The Lord of the Rings",
                Year = 1954,
                Authors = new List<Author> { tolkien },
                Publisher = georgeAllenUnwin,
                Genre = fantasy
            };
            var silmarillion = new Book
            {
                Title = "The Silmarillion",
                Year = 1977,
                Authors = new List<Author> { tolkien },
                Publisher = georgeAllenUnwin,
                Genre = fantasy
            };
            var hitchhikersGuide = new Book
            {
                Title = "The Hitchhiker's Guide to the Galaxy",
                Year = 1979,
                Authors = new List<Author> { adams },
                Publisher = hodderAndStoughton,
                Genre = scienceFiction
            };
            var dune = new Book
            {
                Title = "Dune",
                Year = 1965,
                Authors = new List<Author> { herbert },
                Publisher = chiltonBooks,
                Genre = scienceFiction
            };
            var duneHouseAtreides = new Book
            {
                Title = "Dune: House Atreides",
                Year = 1999,
                Authors = new List<Author> { herbert, anderson },
                Publisher = bantamSpectra,
                Genre = scienceFiction
            };
            var duneTheButlerianJihad = new Book
            {
                Title = "Dune: The Butlerian Jihad",
                Year = 2002,
                Authors = new List<Author> { herbert, anderson },
                Publisher = bantamSpectra,
                Genre = scienceFiction
            };
            context.Books.AddRange(hobbit, lordOfTheRings, silmarillion, hitchhikersGuide, dune, duneHouseAtreides, duneTheButlerianJihad);
            context.SaveChanges();
        }
    }
}
