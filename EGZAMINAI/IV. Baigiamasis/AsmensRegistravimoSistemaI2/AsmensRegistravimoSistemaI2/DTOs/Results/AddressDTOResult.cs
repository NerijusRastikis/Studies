namespace AsmensRegistravimoSistemaI2.DTOs.Results
{
    public class AddressDTOResult
    {
        public long UserPIN { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        // HouseNumber string, nes gali būti namo numeris pvz. 15A
        public string HouseNumber { get; set; }
        public int ApartmentNumber { get; set; }
    }
}
