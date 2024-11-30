using AutoFixture;
using AutoFixture.Xunit2;

namespace BooksApiTesting.Utilities;

public class BookInvalidNullDataAttribute : AutoDataAttribute
{
    public BookInvalidNullDataAttribute() : base(() =>
    {
        var fixture = new Fixture();
        fixture.Customizations.Add(new BookSpecimentBuilder());

        return fixture;
    })
    { }
}