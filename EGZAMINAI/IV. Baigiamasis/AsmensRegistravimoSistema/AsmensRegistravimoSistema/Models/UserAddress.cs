namespace AsmensRegistravimoSistema.Models;

public class UserAddress
{
    public Guid Id { get; set; }
    public string Town { get; set; }
    public string Street { get; set; }
    public int HouseNumber { get; set; }
    public int ApartmentNumber { get; set; }
}