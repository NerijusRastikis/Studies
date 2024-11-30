using AutoFixture;
using AutoFixture.Xunit2;

namespace BooksApiTesting.Utilities;

public class BookDataAttribute : AutoDataAttribute
{
    public BookDataAttribute() : base(() =>
    {
        var fixture = new Fixture();
        fixture.Customizations.Add(new BookSpecimentBuilder());

        return fixture;
    })
    { }
}