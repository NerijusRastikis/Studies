using AsmensRegistravimoSistemaI2.DTOs.Requests;
using AsmensRegistravimoSistemaI2.Mappers.Interfaces;
using AsmensRegistravimoSistemaI2.Models;
using AsmensRegistravimoSistemaI2.Services.Interfaces;

namespace AsmensRegistravimoSistemaI2.Mappers
{
    public class UserMapper : IUserMapper
    {
        private readonly IUserService _userService;

        public UserMapper(IUserService userService)
        {
            _userService = userService;
        }
        public User Map(UserDTORequest dto, Guid id)
        {
            _userService.CreatePasswordHash(dto.Password, out var passwordHash, out var passwordSalt);
            return new User
            {
                Id = id,
                Username = dto.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };
        }
    }
}
