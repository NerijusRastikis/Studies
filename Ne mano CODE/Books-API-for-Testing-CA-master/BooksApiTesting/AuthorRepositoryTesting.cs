using BooksApi;
using BooksApi.Controllers;
using BooksApi.Models;
using BooksApi.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace BooksApiTesting
{
    public class AuthorRepositoryTesting
    {
        [Fact]
        public void Filter_IsCaseUnsensitive()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new ApplicationDbContext(options);
            context.Authors.AddRange(
                new Author { Id = Guid.NewGuid(), FirstName = "Author1", LastName = "A" },
                new Author { Id = Guid.NewGuid(), FirstName = "author1", LastName = "a" }
            );
            context.SaveChanges();

            var repo = new AuthorRepository(context);

            // Act
            var result1 = repo.Filter("Author1", "A");
            var result2 = repo.Filter("author1", "a");

            // Assert
            Assert.Equal(result1, result2);
        }
    }
}
