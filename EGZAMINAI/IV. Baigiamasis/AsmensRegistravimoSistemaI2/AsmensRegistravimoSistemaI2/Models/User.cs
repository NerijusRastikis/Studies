using System.ComponentModel.DataAnnotations;

namespace AsmensRegistravimoSistemaI2.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public RoleTypes Roles { get; set; } = RoleTypes.User;

        // Foreign key to GeneralInformation
        public Guid UserGeneralInformationId { get; set; }

        // Navigation property
        public GeneralInformation GeneralInformation { get; set; }
    }
}