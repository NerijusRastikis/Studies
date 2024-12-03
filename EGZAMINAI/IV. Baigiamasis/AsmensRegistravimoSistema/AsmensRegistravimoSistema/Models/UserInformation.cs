namespace AsmensRegistravimoSistema.Models;

public class UserInformation
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int UserId { get; set; }
    public int PhoneNumber { get; set; }
    public string Email { get; set; }
    public byte[] Photo { get; set; } = null!;
    public UserAddress Address { get; set; }
}