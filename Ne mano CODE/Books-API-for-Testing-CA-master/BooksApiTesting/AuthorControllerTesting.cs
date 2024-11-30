using BooksApi.Controllers;
using BooksApi.Models;
using BooksApi.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BooksApiTesting
{
    public class AuthorControllerTesting
    {
        [Fact]
        public void GetAuthors_Success()
        {
            // Arrange
            var repositoryMock = new Mock<IAuthorRepository>();

            var authors = new List<Author>
    {
        new Author { Id = new Guid(), FirstName = "Author1" },
        new Author { Id = new Guid(), FirstName = "Author2" }
    };
            repositoryMock.Setup(repo => repo.Filter(It.IsAny<string>(), It.IsAny<string>())).Returns(authors);

            var controller = new AuthorController(repositoryMock.Object);

            // Act
            var result = controller.GetAuthors("Author1") as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            var returnedAuthors = Assert.IsAssignableFrom<IEnumerable<Author>>(result.Value);
            var authorsToList = returnedAuthors.ToList();
            Assert.Equal(2, authorsToList.Count());
            Assert.Contains(authorsToList, a => a.FirstName == "Author1");
        }
    }
}