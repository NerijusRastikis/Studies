using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Mvc;
using Moq;
using P103_ExternalApi.Controllers;
using P103_ExternalApi.Dtos;
using P103_ExternalApi.Services;

namespace BooksApiControllerTests
{
    public class BooksApiControllerTesting
    {
        [Fact]
        public async Task BooksApiController_GetBook_NotFound()
        {
            //Arrange
            var booksApiClientMock = new Mock<IBooksApiClient>();
            var booksApiMapperMock = new Mock<IBooksMapper>();

            //SUT
            var sut = new BooksApiController(booksApiClientMock.Object, booksApiMapperMock.Object);

            //Act
            var result = await sut.GetBook("1", 1);

            //Assert
            Assert.IsType<NotFoundResult>(result);

        }
        [Theory, AutoData]
        public async Task BooksApiController_GetBook_Correct(BookApiResult bookDTO)
        {
            //Arrange
            var booksApiClientMock = new Mock<IBooksApiClient>();
            var booksApiMapperMock = new Mock<IBooksMapper>();

            //SUT
            var sut = new BooksApiController(booksApiClientMock.Object, booksApiMapperMock.Object);
            booksApiClientMock.Setup(x => x.GetBook(It.IsAny<string>(),It.IsAny<int>())).ReturnsAsync(bookDTO);

            //Act
            var result = await sut.GetBook("1", 1);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Theory, AutoData]
        public async Task BooksApiController_GetBooks_Correct(string connectionId)
        {
            //Arrange
            var booksApiClientMock = new Mock<IBooksApiClient>();
            var booksApiMapperMock = new Mock<IBooksMapper>();

            //SUT
            var sut = new BooksApiController(booksApiClientMock.Object, booksApiMapperMock.Object);
            booksApiClientMock.Setup(x => x.GetBooks(It.IsAny<string>()));

            //Act
            var result = await sut.GetBooks(connectionId);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Theory, AutoData]
        public async Task BooksApiController_GetBooks_NotFound(string connectionId)
        {
            //Arrange
            var booksApiClientMock = new Mock<IBooksApiClient>();
            var booksApiMapperMock = new Mock<IBooksMapper>();

            //SUT
            var sut = new BooksApiController(booksApiClientMock.Object, booksApiMapperMock.Object);
            booksApiClientMock.Setup(x => x.GetBooks(It.IsAny<string>())).ReturnsAsync((IEnumerable<BookApiResult>)null);

            //Act
            var result = await sut.GetBooks(connectionId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
        [Theory, AutoData]
        public async Task BooksApiController_GetBooks_Exception(string connectionId)
        {
            //Arrange
            var booksApiClientMock = new Mock<IBooksApiClient>();
            var booksApiMapperMock = new Mock<IBooksMapper>();

            //SUT
            var sut = new BooksApiController(booksApiClientMock.Object, booksApiMapperMock.Object);
            booksApiClientMock.Setup(x => x.GetBooks(It.IsAny<string>())).Throws<Exception>();

            //Act
            var result = await sut.GetBooks(connectionId);

            //Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}