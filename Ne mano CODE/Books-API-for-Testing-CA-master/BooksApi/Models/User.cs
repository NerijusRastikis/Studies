using System;

namespace BooksApi.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
