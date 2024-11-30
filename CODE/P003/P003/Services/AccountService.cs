using P003.Database;
using P003.Models;

namespace P003.Services;

public class AccountService : IAccountService
{
    private readonly BooksDatabase _booksDatabase;

    public AccountService(BooksDatabase booksDatabase)
    {
        _booksDatabase = booksDatabase;
    }

    public Account SignUpNewAccount(string username, string password)
    {
        var account = CreateAccount(username, password);
        _booksDatabase.Accounts.Add(account);
        _booksDatabase.SaveChanges();
        return account;
    }

    public Account CreateAccount(string username, string password)
    {
        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
        var account = new Account
        {
            Username = username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Role = "User"
        };
        return account;
    }

    public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }
}