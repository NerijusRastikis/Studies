using BooksApi.DTOs;
using BooksApi.Models;
using BooksApi.Services.Repositories;

namespace BooksApi.Services
{
    public interface IBookService
    {
        ResponseDto AddBook(Book book);
        Book GetBook(string title);
        void RemoveBook(Guid id);
    }
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IGenreRepository _genreRepository;
        private readonly IISBNValidator _isbnValidator;

        public BookService(IBookRepository repository, 
            IGenreRepository genreRepository, 
            IISBNValidator isbnValidator)
        {
            _repository = repository;
            _genreRepository = genreRepository;
            _isbnValidator = isbnValidator;
        }

        public ResponseDto AddBook(Book book)
        {
            var existingBook = _repository.GetBook(book.Title);
            if (existingBook is not null)
                return new ResponseDto(false, "Book already exist");

            if (book.Authors.Count < 1)
                return new ResponseDto(false, "Authors should be at least 1");

            if (book.Authors.Count > 5)
                return new ResponseDto(false, "Authors should not be more than 5");

            if (!(book.Pages > 1))
                return new ResponseDto(false, "Pages should be at least 1");

            if (!(new List<string> { "Hardcover", "Paperback", "E-book", "Audiobook" }).Contains(book.CoverType))
                return new ResponseDto(false, "Invalid cover type");

            var genre = _genreRepository.Get(book.GenreId);
            if (genre is null)
                return new ResponseDto(false, "Genre does not exist");

            var isbnValidation = _isbnValidator.Validate(book.ISBN);

            if (!isbnValidation.IsValid)
                return new ResponseDto(false, isbnValidation.Message);

            var id = _repository.AddBook(book);
            return new ResponseDto(true, id.ToString());
        }

        public Book GetBook(string title)
        {
            return _repository.GetBook(title);
        }

        public void RemoveBook(Guid id)
        {
            _repository.RemoveBook(id);
        }
    }
}
