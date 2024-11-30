using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P001.Models;

namespace P001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly List<Book> _books;
        public AuthorsController()
        {
            _books = new List<Book>
            {
                new Book { Id = 1, Pavadinimas = "1984", Autorius = {
                        new Author {Id = 1, Vardas = "Pirmas", Pavarde = "Pirmoji"},
                        new Author {Id = 2, Vardas = "Pirmas", Pavarde = "Antroji"}
                    }, LeidybosMetai = 1949 },
                new Book { Id = 2, Pavadinimas = "Animal Farm", Autorius = { new Author {Id = 3, Vardas = "George", Pavarde = "Orwell" } }, LeidybosMetai = 1945 },
                new Book { Id = 3, Pavadinimas = "Homage to Catalonia", Autorius = { new Author {Id = 3, Vardas = "George", Pavarde = "Orwell" } }, LeidybosMetai = 1938 },
                new Book { Id = 4, Pavadinimas = "To Kill a Mockingbird", Autorius = {
                        new Author {Id = 4, Vardas = "Harper", Pavarde = "Lee" },
                        new Author {Id = 3, Vardas = "George", Pavarde = "Orwell" } }, LeidybosMetai = 1960 },
                new Book { Id = 5, Pavadinimas = "Pride and Prejudice", Autorius = { new Author {Id = 5, Vardas = "Jane", Pavarde = "Austen" } }, LeidybosMetai = 1813 },
                new Book { Id = 6, Pavadinimas = "The Great Gatsby", Autorius = { new Author {Id = 6, Vardas = "F. Scott", Pavarde = "Fitzgerald" } }, LeidybosMetai = 1925 },
                new Book { Id = 7, Pavadinimas = "Moby Dick", Autorius = { new Author {Id = 7, Vardas = "Herman", Pavarde = "Melville" } }, LeidybosMetai = 1851 },
                new Book { Id = 8, Pavadinimas = "War and Peace", Autorius = { new Author {Id = 8, Vardas = "Leo", Pavarde = "Tolstoy" } }, LeidybosMetai = 1869 },
                new Book { Id = 9, Pavadinimas = "The Catcher in the Rye", Autorius = { new Author {Id = 9, Vardas = "J.D.", Pavarde = "Salinger" } }, LeidybosMetai = 1951 },
                new Book { Id = 10, Pavadinimas = "The Hobbit", Autorius = { new Author {Id = 10, Vardas = "J.R.R.", Pavarde = "Tolkien" } }, LeidybosMetai = 1937 }
            };
        }

        [HttpGet]
        public IEnumerable<Author> GetAllAuthors()
        {
            List<Author> authors = new List<Author>();

            foreach (var book in _books)
            {
                foreach (var author in book.Autorius)
                {
                    authors.Add(author);
                }
            }
            return authors;
        }
        [HttpGet("{id}")]
        public Author? GetAuthorById(int id)
        {
            foreach (var book in _books)
            {
                var author = book.Autorius.FirstOrDefault(author => author.Id == id);
                if (author != null)
                {
                    return author;
                }
            }
            return null;
        }
        [HttpGet("{id}/books")]
        public IEnumerable<Author> GetAuthorList(int id)
        {
            var authors = new List<Author>();

            foreach (var book in _books)
            {
                authors.AddRange(book.Autorius.Where(author => author.Id == id));
            }

            return authors;
        }
        [HttpGet("{id}/FilterAuthorBooks")]
        public IEnumerable<Book> FilterAuthorBooks(int id, string pavadinimas)
        {
            return _books
                .Where(book => book.Autorius.Any(author => author.Id == id) &&
                               book.Pavadinimas.Contains(pavadinimas))
                .ToList();
        }
    }
}
