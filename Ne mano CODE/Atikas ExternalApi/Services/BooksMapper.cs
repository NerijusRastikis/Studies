using P103_ExternalApi.Dtos;

namespace P103_ExternalApi.Services
{
    public interface IBooksMapper
    {
        BookResult Map(BookApiResult o);
        IEnumerable<BookResult> Map(IEnumerable<BookApiResult> o);
        BookApiRequest Map(BookRequest req);
    }
    public class BooksMapper : IBooksMapper
    {
        public BookResult Map(BookApiResult o)
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
        public IEnumerable<BookResult> Map(IEnumerable<BookApiResult> o)
        {
            return o.Select(Map);
        }

        public BookApiRequest Map(BookRequest req)
        {
            return new BookApiRequest
            {
                Title = req.Title,
                Authors = req.Authors,
                Genres = req.Genres,
                Year = req.Year
            };
        }
    }
}
