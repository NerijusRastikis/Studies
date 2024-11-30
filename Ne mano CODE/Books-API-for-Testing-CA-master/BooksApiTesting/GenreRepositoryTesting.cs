using BooksApi;
using BooksApi.Models;
using BooksApi.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApiTesting
{
    public class GenreRepositoryTesting
    {
        [Fact]
        public void GetGenre_Success()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new ApplicationDbContext(options);
            var repoGenre = new GenreRepository(context);
            var repoBook = new BookRepository(context);

            var genreId = new Guid("2168d616-87da-4c55-b902-de628b1f3c07");
            var bookId = new Guid("2168d616-87da-4c55-b902-de628b1f3c08");

            repoBook.AddBook(new Book
            {
                Id = bookId,
                Title = "Knyga",
                CoverType = "Digital",
                Genre = new Genre { Id = genreId, Name = "Science Fiction" },
                ISBN = "Kazkas"
            });
            context.SaveChanges();

            // Act
            var result = repoGenre.Get(genreId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(genreId, result.Id);
        }

    }
}
