using System.Collections;
using AutoFixture.Kernel;
using BooksApi.Models;

namespace BooksApiTesting.Utilities;

public class BookSpecimentBuilder : ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        var type = request as Type;
        if (type == typeof(Book))
        {
            return new Book
            {
                Id = Guid.NewGuid(),
                Title = "Knyga",
                CoverType = "Paperback",
                Pages = 100,
                Authors = new List<Author>
                    {
                        new Author { Id = new Guid(), FirstName = "FirstAuthorName", LastName = "FirstAuthorLastName" },
                        new Author {Id = new Guid(), FirstName = "SecondAuthorName", LastName = "SecondAuthorLastName" }
                    }
            };
        }
        return new NoSpecimen();
    }
}