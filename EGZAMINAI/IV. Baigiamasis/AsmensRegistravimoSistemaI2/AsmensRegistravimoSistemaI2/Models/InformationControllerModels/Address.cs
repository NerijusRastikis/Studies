using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsmensRegistravimoSistemaI2.Models.InformationControllerModels
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(GeneralInformation))]
        public long UserPIN { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        // HouseNumber string, nes gali būti namo numeris pvz. 15A
        public string HouseNumber { get; set; }
        public int ApartmentNumber { get; set; }
    }
}
