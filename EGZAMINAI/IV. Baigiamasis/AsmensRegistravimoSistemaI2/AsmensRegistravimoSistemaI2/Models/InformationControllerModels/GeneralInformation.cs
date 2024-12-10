using AsmensRegistravimoSistemaI2.Models.ImageControllerModels;
using AsmensRegistravimoSistemaI2.Models.InformationControllerModels;
using AsmensRegistravimoSistemaI2.Models.UserControllerModels;
using System.ComponentModel.DataAnnotations;

public class GeneralInformation
{
    public Guid Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public long UserPIN { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public Address GIAddress { get; set; }
    [Required]

    public Image GIImage { get; set; }


    // Foreign Key
    public Guid ProfilePhotoId { get; set; }
    public Guid UserAddressId { get; set; }
}
