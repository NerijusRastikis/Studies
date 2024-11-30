using BooksApi;
using BooksApi.Models;
using BooksApi.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApiTesting
{
    public class BookRepositoryTesting
    {
        [Fact]
        public void GetBook_RetrieveExistingBook_Success()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            using var context = new ApplicationDbContext(options);
            context.Books.AddRange(
                new Book { Id = new Guid(), Title = "Pirma", Pages = 100, CoverType = "Hard", ISBN = "kazkas" },
                new Book { Id = new Guid(), Title = "Antra", Pages = 200, CoverType = "Soft", ISBN = "dar kazkas" }
                );
            context.SaveChanges();

            var repo = new BookRepository(context);

            //Act
            var result = repo.GetBook("Pirma");

            //Assert
            Assert.Equal(100, result.Pages);
        }
        [Fact]
        public void GetBook_RetrieveExistingBook_NoBook()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            using var context = new ApplicationDbContext(options);
            context.Books.AddRange(
                new Book { Id = new Guid(), Title = "Pirma", Pages = 100, CoverType = "Hard", ISBN = "kazkas" },
                new Book { Id = new Guid(), Title = "Antra", Pages = 200, CoverType = "Soft", ISBN = "dar kazkas" }
                );
            context.SaveChanges();

            var repo = new BookRepository(context);

            //Act
            var result = repo.GetBook("Pirma");

            //Assert
            Assert.NotEqual(101, result.Pages);
        }
        [Fact]
        public void AddBook_Success()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            using var context = new ApplicationDbContext(options);

            var newObject = new Book { Id = new Guid(), Title = "Knyga", CoverType = "Digital", ISBN = "raudoniolika" };
            //Act
            var repo = new BookRepository(context);
            repo.AddBook(newObject);
            context.SaveChanges();



            //Assert
            Assert.Equal("Knyga", repo.GetBook("Knyga").Title);
        }
        [Fact]
        public void RemoveBook_Success()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            using var context = new ApplicationDbContext(options);
            var repo = new BookRepository(context);
            repo.AddBook(new Book { Id = new Guid("2168d616-87da-4c55-b902-de628b1f3c07"), Title = "Knyga", CoverType = "Digital", ISBN = "Vienas" });
            //Act
            repo.RemoveBook(new Guid("2168d616-87da-4c55-b902-de628b1f3c07"));
            context.SaveChanges();

            var result = repo.GetBook("Knyga");
            //Assert
            Assert.Null(result);
        }
    }
}
