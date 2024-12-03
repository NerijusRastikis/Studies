using AsmensRegistravimoSistemaI2.Models.ImageControllerModels;
using System.ComponentModel.DataAnnotations;

namespace AsmensRegistravimoSistemaI2.Models.InformationControllerModels
{
    public class GeneralInformation
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public long UserPIN { get; set; }
        // PhoneNumber string, nes gali asmenys bandyti vesti numerį su pvz. +370 (tad geriau tiesiog validuoti ir supars'inti)
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Image ProfilePhoto { get; set; }
        [Required]
        public Address UserAddress { get; set; }
    }
}
