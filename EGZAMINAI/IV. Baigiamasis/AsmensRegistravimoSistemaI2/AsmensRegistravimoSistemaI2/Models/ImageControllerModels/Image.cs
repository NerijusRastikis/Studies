using AsmensRegistravimoSistemaI2.Models.UserControllerModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsmensRegistravimoSistemaI2.Models.ImageControllerModels
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(User))]
        public string Username { get; set; }
        public byte[] Photo { get; set; }
    }
}