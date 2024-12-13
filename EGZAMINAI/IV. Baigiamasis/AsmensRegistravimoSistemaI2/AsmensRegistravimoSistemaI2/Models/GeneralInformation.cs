using AsmensRegistravimoSistemaI2.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;

public class GeneralInformation
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public long PersonalCode { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public byte[] GIImage { get; set; }

    // Foreign key to Address
    public Guid GIAddressId { get; set; }

    // Navigation property
    public Address GIAddress { get; set; }
}