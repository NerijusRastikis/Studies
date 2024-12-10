using AsmensRegistravimoSistemaI2.DTOs.Requests;
using AsmensRegistravimoSistemaI2.DTOs.Results;
using AsmensRegistravimoSistemaI2.Models;

namespace AsmensRegistravimoSistemaI2.Mappers.Interfaces
{
    public interface IAddressMapper
    {
        AddressDTOResult Map(Address address);
        Address Map(AddressDTORequest address, Guid id);
    }
}