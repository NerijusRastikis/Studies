using BooksApi.Models;

namespace BooksApi.Services
{
    public interface IBookMapper
    {
        Book Map(CreateBookRequest o);
        GetBookResult Map(Book o);
        IEnumerable<GetBookResult> Map(IEnumerable<Book> o);
    }
    public class BookMapper : IBookMapper
    {
        public Book Map(CreateBookRequest o)
        {
            return new Book
            {
                Title = o.Title,
                GenreId = o.GenreId,
                Pages = o.Pages,
                Year = o.Year,
                ISBN = o.ISBN
            };
        }

        public GetBookResult Map(Book o)
        {
            return new GetBookResult
            {
                Title = o.Title,               
                Pages = o.Pages,
                Year = o.Year,
                ISBN = o.ISBN,
                Genre = o.Genre.Name,
                Authors = o.Authors.Select(a => a.FirstName + " " + a.LastName).ToList()
            };
        }

        public IEnumerable<GetBookResult> Map(IEnumerable<Book> o)
        {
            return o.Select(Map);
        }


    }
}
