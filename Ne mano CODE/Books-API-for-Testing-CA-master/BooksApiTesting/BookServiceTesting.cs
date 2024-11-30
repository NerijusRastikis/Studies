using AutoFixture.Xunit2;
using BooksApi.Models;
using BooksApi.Services;
using BooksApi.Services.Repositories;
using BooksApiTesting.Utilities;
using Moq;

namespace BooksApiTesting;

public class BookServiceTesting
{
    [Theory, BookData]
    public void AddBook_ShouldAddBook_Success(Book book)
    {
        //Arrange
        var bookRepositoryMock = new Mock<IBookRepository>();
        var genreRepositoryMock = new Mock<IGenreRepository>();
        var iSbnValidatorMock = new Mock<IISBNValidator>();

        bookRepositoryMock
            .Setup(repo => repo.GetBook(book.Title))
            .Returns((Book)null!);
        genreRepositoryMock
            .Setup(repo => repo.Get(book.GenreId))
            .Returns(new Genre { Id = book.GenreId, Name = "Fiction" });
        iSbnValidatorMock
            .Setup(validator => validator.Validate(book.ISBN))
            .Returns(new ValidationResult(true, "ISBN is valid"));
        
        var bookService = new BookService(bookRepositoryMock.Object, genreRepositoryMock.Object, iSbnValidatorMock.Object);
        
        //Act
        var result = bookService.AddBook(book);
        
        //Assert
        Assert.True(result.IsSuccess);
    }

    [Theory, BookData]
    public void GetBook_ShouldGiveResponse_BookAlreadyExist(Book book)
    {
        
    }
}