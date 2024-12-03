namespace AsmensRegistravimoSistemaI2.DTOs.Requests
{
    public class AddressDTORequest
    {
        public int UserPIN { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        // HouseNumber string, nes gali būti namo numeris pvz. 15A
        public string HouseNumber { get; set; }
        public int ApartmentNumber { get; set; }
    }
}
