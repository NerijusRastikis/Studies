using System.ComponentModel.DataAnnotations;

namespace AsmensRegistravimoSistemaI2.Models.UserControllerModels
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Username { get; set; }
        //[Required]
        //public string Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public RoleTypes Roles { get; set; } = RoleTypes.User;
    }
}