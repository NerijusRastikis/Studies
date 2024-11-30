using BooksApi.DTOs;
using BooksApi.Models;
using BooksApi.Services.Repositories;
using System.Security.Cryptography;

namespace BooksApi.Services
{
    public interface IUserService
    {
        ResponseDto Signup(string username, string password);
        ResponseDto Login(string username, string password);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public ResponseDto Login(string username, string password)
        {
            var user = _repository.GetUser(username);
            if (user is null)
                return new ResponseDto(false, "Username or password does not match");

            if (!VerifyPasswordHash(password, user.Password, user.PasswordSalt))
                return new ResponseDto(false, "Username or password does not match");

            return new ResponseDto(true, "User logged in");
        }

        public ResponseDto Signup(string username, string password)
        {
            var user = _repository.GetUser(username);
            if (user is not null)
                return new ResponseDto(false, "User already exists");

            user = CreateUser(username, password);
            _repository.SaveUser(user);
            return new ResponseDto(true);
        }

        private User CreateUser(string username, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = username,
                Password = passwordHash,
                PasswordSalt = passwordSalt
            };

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash);
        }
    }
}
