using AsmensRegistravimoSistema.Enums;
using AsmensRegistravimoSistema.Models;

namespace AsmensRegistravimoSistema.DTOs.Requests
{
    public class UserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] PasswordSalt { get; set; } = null!;
        public RoleTypes Role { get; set; } = RoleTypes.User;
        public UserInformation UserInfo { get; set; } = new UserInformation();
    }
}
