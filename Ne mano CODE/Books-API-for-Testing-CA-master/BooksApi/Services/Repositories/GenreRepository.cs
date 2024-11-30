using BooksApi.Models;

namespace BooksApi.Services.Repositories
{
    public interface IGenreRepository
    {
        Genre? Get(Guid id);
    }
    public class GenreRepository: IGenreRepository
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Genre? Get(Guid id)
        {
            return _context.Genres.Find(id);

        }
    }
}
