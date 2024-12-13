using AsmensRegistravimoSistemaI2.Models;
using System.Security.Cryptography;
using System.Text;

namespace AsmensRegistravimoSistemaI2.Database.InitialData
{
    public static class UsersInitialData
    {
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA256();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
        public static List<User> Users => new()
        {
            Pirmas(),
            Antras(),
            Trecias(),
            Ketvirtas(),
            Penktas()
        };
        private static User Pirmas()
        {
            CreatePasswordHash("pirmas", out var passwordHash, out var passwordSalt);
            return new User
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Username = "pirmas",
                Password = "pirmas",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Roles = RoleTypes.User,
                UserGeneralInformationId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            };
        }
        private static User Antras()
        {
            CreatePasswordHash("antras", out var passwordHash, out var passwordSalt);
            return new User
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Username = "antras",
                Password = "antras",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Roles = RoleTypes.User,
                UserGeneralInformationId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            };
        }
        private static User Trecias()
        {
            CreatePasswordHash("trecias", out var passwordHash, out var passwordSalt);
            return new User
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Username = "trecias",
                Password = "trecias",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Roles = RoleTypes.Admin,
                UserGeneralInformationId = Guid.Parse("00000000-0000-0000-0000-000000000003")
            };
        }
        private static User Ketvirtas()
        {
            CreatePasswordHash("ketvirtas", out var passwordHash, out var passwordSalt);
            return new User
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                Username = "ketvirtas",
                Password = "ketvirtas",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Roles = RoleTypes.User,
                UserGeneralInformationId = Guid.Parse("00000000-0000-0000-0000-000000000004")
            };
        }
        private static User Penktas()
        {
            CreatePasswordHash("penktas", out var passwordHash, out var passwordSalt);
            return new User
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                Username = "penktas",
                Password = "penktas",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Roles = RoleTypes.User,
                UserGeneralInformationId = Guid.Parse("00000000-0000-0000-0000-000000000005")
            };
        }
    }
}
