using P003.Models;

namespace P003.Services;

public interface IAccountService
{
    Account SignUpNewAccount(string username, string password);
    Account CreateAccount(string username, string password);
    void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
}