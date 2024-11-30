using BooksApi.Models;

namespace BooksApi.Services.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> Filter(string firstName, string lastName);
    }
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Author> Filter(string firstName, string lastName)
        {
            var authors = _context.Authors.Where(a => a.FirstName.Contains(firstName, StringComparison.InvariantCultureIgnoreCase)
                                                   || a.LastName.Contains(lastName, StringComparison.InvariantCultureIgnoreCase))
                                          .ToList();
            return authors;
        }
    }
}
