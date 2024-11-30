using AutoFixture.Xunit2;
using BooksApi.Models;
using BooksApi.Services;
using Moq;

namespace BooksApiTesting;

public class BookMapperTesting
{
    [Theory, AutoData]
    public void Map_GetBookResult_Success(Book book)
    {
        // Arrange
        var expectedResult = new GetBookResult
        {
            Id = book.Id,
            Title = book.Title,
            Pages = book.Pages,
            Year = book.Year,
            ISBN = book.ISBN,
            Genre = book.Genre.Name,
            Authors = book.Authors.Select(a => a.FirstName + " " + a.LastName).ToList()
        };

        var bookMapperMock = new Mock<IBookMapper>();
        bookMapperMock
            .Setup(m => m.Map(book))
            .Returns(expectedResult);

        var bookMapper = bookMapperMock.Object;

        // Act
        var result = bookMapper.Map(book);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(book.Id, result.Id);
        Assert.Equal(expectedResult.Title, result.Title);
        Assert.Equal(expectedResult.Genre, result.Genre);
        Assert.Equal(expectedResult.Authors, result.Authors);
    }
    //         public IEnumerable<GetBookResult> Map(IEnumerable<Book> o)
    // {
    //     return o.Select(Map);
    // }
    // Netestavau, nes daro tą patį, ką ir ištestuotas metodas, tik jis daro su kiekvienu objektu.
}