using P0004.DTOs;
using P004.DTOs;

namespace P0004.Services
{
    public interface IBooksMapper
    {
        BookResult Map(BookAPIResult o);
        IEnumerable<BookResult> Map(IEnumerable<BookAPIResult> o);
        BookAPIResult Map(BookRequest req);
    }
    public class BooksMapper : IBooksMapper
    {
        public BookResult Map(BookAPIResult o)
        {
            return new BookResult
            {
                Id = o.Id,
                Title = o.Title,
                Authors = o.Authors,
                Genres = o.Genres,
                Year = o.Year
            };
        }
        public IEnumerable<BookResult> Map(IEnumerable<BookAPIResult> o)
        {
            return o.Select(Map);
        }

        public BookAPIResult Map(BookRequest req)
        {
            return new BookAPIResult
            {
                Title = req.Title,
                Authors = req.Authors,
                Genres = req.Genres,
                Year = req.Year
            };
        }
    }
}
