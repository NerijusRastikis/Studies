using BooksApi;
using BooksApi.Models;
using BooksApi.Services.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BooksApiTesting;

public class UserRepositoryTesting
{
    [Fact]
    public void GetUser_ShouldReturnUser()
    {
        //Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        using var context = new ApplicationDbContext(options);
        var repo = new UserRepository(context);
        var user = new User { Id = new Guid("ffce08d4-eff7-44a5-8597-0439dc85b1b3"), Username = "username", Password = [100], PasswordSalt = [200]};
        //Tuo pačiu ištestavau ar veikia SaveUser metodas, nes jei nebūtų suveikęs, šis testas irgi būtų grąžinęs teigiamą testo rezultatą
        repo.SaveUser(user);
        //Act
        var result = repo.GetUser(user.Username);
        //Assert
        Assert.Equal(user, result);
    }
}