using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsmensRegistravimoSistemaI2.Models
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }

        public string Town { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public int ApartmentNumber { get; set; }
    }
}
