using Moq;
using P003.Repositories;

namespace BooksControllerTests
{
    public class BooksControllerTesting
    {
        [Fact]
        public async Task BooksController_GetById_NotFound()
        {
            // Arrange
            var booksRepository = new Mock(IBookRepository);
        }
    }
}