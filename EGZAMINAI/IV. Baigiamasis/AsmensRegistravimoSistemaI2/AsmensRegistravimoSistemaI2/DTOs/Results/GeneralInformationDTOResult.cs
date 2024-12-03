using AsmensRegistravimoSistemaI2.Models.ImageControllerModels;
using AsmensRegistravimoSistemaI2.Models.InformationControllerModels;

namespace AsmensRegistravimoSistemaI2.DTOs.Results
{
    public class GeneralInformationDTOResult
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long UserPIN { get; set; }
        // PhoneNumber string, nes gali asmenys bandyti vesti numerį su pvz. +370 (tad geriau tiesiog validuoti ir supars'inti)
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Image ProfilePhoto { get; set; }
        public Address UserAddress { get; set; }
    }
}
