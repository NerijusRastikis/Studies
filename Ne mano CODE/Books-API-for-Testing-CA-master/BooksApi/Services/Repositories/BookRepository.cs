using BooksApi.Models;

namespace BooksApi.Services.Repositories
{
    public interface IBookRepository
    {
        Book GetBook(string title);
        Guid AddBook(Book book);
        void RemoveBook(Guid id);
    }
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Book GetBook(string title)
        {
            return _context.Books.SingleOrDefault(x => x.Title == title);
        }

        public Guid AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book.Id;
        }

        public void RemoveBook(Guid id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
