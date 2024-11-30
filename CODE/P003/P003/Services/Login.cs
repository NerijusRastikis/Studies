using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication;
using P003.Database;

namespace P003.Services
{
    public class Login
    {
        private readonly BooksDatabase _booksDatabase;
        private readonly IAccountService _accountService;

        public Login(BooksDatabase booksDatabase, IAccountService accountService)
        {
            _booksDatabase = booksDatabase;
            _accountService = accountService;
        }

        // Authenticate method to validate username and password
        public bool Authenticate(string username, string password)
        {
            var account = _booksDatabase.Accounts.FirstOrDefault(a => a.Username == username);

            if (account == null) return false; // Account not found
            
            return VerifyPasswordHash(password, account.PasswordHash, account.PasswordSalt);
        }

        // Verifies the password hash with the stored hash
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt); // Corrected to HMACSHA512
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            
            return computedHash.SequenceEqual(passwordHash); // Compares the hashes
        }

        public bool LoginUser(string username, string password, out string role)
        {
            var account = _booksDatabase.Accounts.FirstOrDefault(a => a.Username == username);
            role = account.Role;
            if (VerifyPasswordHash(password, account.PasswordHash, account.PasswordSalt))
            {
                return true;
            }
            return false;
        }
    }
}