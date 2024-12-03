using System.ComponentModel.DataAnnotations;
using AsmensRegistravimoSistema.Enums;

namespace AsmensRegistravimoSistema.Models;

public class User
{
    [Key]
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public byte[] PasswordSalt { get; set; } = null!;
    public RoleTypes Role { get; set; } = RoleTypes.User;
    public UserInformation UserInfo { get; set; } = new UserInformation();
}