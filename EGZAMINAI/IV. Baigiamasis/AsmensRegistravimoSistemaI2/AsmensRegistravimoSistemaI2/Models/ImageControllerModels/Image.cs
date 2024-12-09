using AsmensRegistravimoSistemaI2.Models.UserControllerModels;
using System.ComponentModel.DataAnnotations;

namespace AsmensRegistravimoSistemaI2.Models.ImageControllerModels
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public byte[] Photo { get; set; }

        public User User { get; set; }
    }
}