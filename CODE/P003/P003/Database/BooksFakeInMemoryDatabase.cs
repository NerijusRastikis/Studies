using P003.Enums;
using P003.Models;
using static P003.Models.Book;

namespace P003.Database
{
    public class BooksFakeInMemoryDatabase
    {
        private readonly List<Book> _books = new List<Book>
{
    new Book { Id = 1, Title = "Dune", Author = "Frank Herbert", Cover = CoverType.Hard },
    new Book { Id = 2, Title = "Neuromancer", Author = "William Gibson", Cover = CoverType.Soft },
    new Book { Id = 3, Title = "Foundation", Author = "Isaac Asimov", Cover = CoverType.Digital },
    new Book { Id = 4, Title = "Hyperion", Author = "Dan Simmons", Cover = CoverType.Soft },
    new Book { Id = 5, Title = "Snow Crash", Author = "Neal Stephenson", Cover = CoverType.Hard },
    new Book { Id = 6, Title = "The Left Hand of Darkness", Author = "Ursula K. Le Guin", Cover = CoverType.Digital },
    new Book { Id = 7, Title = "The Expanse: Leviathan Wakes", Author = "James S.A. Corey", Cover = CoverType.Soft },
    new Book { Id = 8, Title = "2001: A Space Odyssey", Author = "Arthur C. Clarke", Cover = CoverType.Hard },
    new Book { Id = 9, Title = "Do Androids Dream of Electric Sheep?", Author = "Philip K. Dick", Cover = CoverType.Digital },
    new Book { Id = 10, Title = "The Stars My Destination", Author = "Alfred Bester", Cover = CoverType.Soft },
    new Book { Id = 11, Title = "The Moon is a Harsh Mistress", Author = "Robert A. Heinlein", Cover = CoverType.Hard },
    new Book { Id = 12, Title = "I, Robot", Author = "Isaac Asimov", Cover = CoverType.Digital }, // Same author as Id 3
    new Book { Id = 13, Title = "The Dispossessed", Author = "Ursula K. Le Guin", Cover = CoverType.Soft }, // Same author as Id 6
    new Book { Id = 14, Title = "Childhood's End", Author = "Arthur C. Clarke", Cover = CoverType.Hard },
    new Book { Id = 15, Title = "The Gods Themselves", Author = "Isaac Asimov", Cover = CoverType.Digital } // Same author as Id 3 and Id 12
};


        public List<Book> GetAllBooks()
        {
            return _books;
        }

        public Book? GetBook(int id)
        {
            return _books.Find(x => x.Id == id);
        }
        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            var index = _books.FindIndex(x => x.Id == book.Id);
            if (index != -1)
            {
                _books[index] = book;
            }
        }
        public void DeleteBook(int id)
        {
            var index = _books.FindIndex(x => x.Id == id);
            if (index != -1)
            {
                _books.RemoveAt(index);
            }
        }

    }
}
