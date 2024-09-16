using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLirEL.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        public required int Year { get; set; }
        public ICollection<Author> Authors { get; set; } = new List<Author>();

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

    }

    public class Genre
    {
        public int GenreId { get; set; }
        public required string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }

    public class Publisher
    {
        public int PublisherId { get; set; }
        public required string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }

    public class Author
    {
        public int AuthorId { get; set; }
        public required string FullName { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }

    public class Country
    {
        public int CountryId { get; set; }
        public required string Name { get; set; }
        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}