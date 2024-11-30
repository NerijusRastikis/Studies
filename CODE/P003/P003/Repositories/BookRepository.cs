using P003.Controllers;
using P003.Database;
using P003.DTO;
using P003.Models;

namespace P003.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BooksDatabase _booksDatabase;
        private readonly ILogger<BooksController> _logger;

        public BookRepository(BooksDatabase booksDatabase, ILogger<BooksController> logger)
        {
            _booksDatabase = booksDatabase;
            _logger = logger;
        }
        public List<Book> GetAll()
        {
            return _booksDatabase.Books.ToList();
        }
        public Book? GetBookById(int id)
        {
            var book = _booksDatabase.Books.ToList().Find(x => x?.Id == id);

            if (book is null)
            {
                _logger.LogError($"Book was not found. Id: {id}, time: {DateTime.UtcNow}");
            }

            return book;
        }
        public void Post(Book newBook)
        {
            try
            {
                _booksDatabase.Add(newBook);
                _logger.LogInformation($"New book added. Title - {newBook.Title}, author - {newBook.Author}, cover - {newBook.Cover} | Time created: {DateTime.UtcNow}");
                _booksDatabase.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} at time {DateTime.UtcNow}", ex);
            }
        }
        public void Put(Book updatedBook, int id)
        {
            var selectedBook = _booksDatabase.Books.ToList().Find(x => x.Id == id);
            if (selectedBook is null)
            {
                _logger.LogError($"Book was not found. Id: {id}, time: {DateTime.UtcNow}");
            }
            selectedBook.Title = updatedBook.Title;
            selectedBook.Author = updatedBook.Author;
            selectedBook.Cover = updatedBook.Cover;
            _logger.LogInformation($"Book was updated with new information: title - {updatedBook.Title}, author - {updatedBook.Author}, cover - {updatedBook.Cover} | Time: {DateTime.UtcNow}");
            _booksDatabase.SaveChanges();
        }
        public void Delete(int id)
        {
            var bookToRemove = _booksDatabase.Books.ToList().Find(x => x.Id == id);
            if (bookToRemove is null)
            {
                _logger.LogError($"Book was not found. Id: {id}, time: {DateTime.UtcNow}");
            }
            _logger.LogInformation($"Book was deleted successfully. Book Id: {id}, time: {DateTime.Now}");
            _booksDatabase.Remove(bookToRemove);
            _booksDatabase.SaveChanges();
        }
    }
}
