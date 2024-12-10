using AsmensRegistravimoSistemaI2.DTOs.Requests;
using AsmensRegistravimoSistemaI2.DTOs.Results;
using AsmensRegistravimoSistemaI2.Mappers.Interfaces;
using AsmensRegistravimoSistemaI2.Models;

namespace AsmensRegistravimoSistemaI2.Mappers
{
    public class AddressMapper : IAddressMapper
    {
        // For getting Address from DB
        public AddressDTOResult Map(Address address)
        {
            return new AddressDTOResult
            {
                Town = address.Town,
                Street = address.Street,
                HouseNumber = address.HouseNumber,
                ApartmentNumber = address.ApartmentNumber,
            };
        }
        // For uploading Address to DB
        public Address Map(AddressDTORequest address, Guid id)
        {
            return new Address
            {
                Id = id,
                Town = address.Town,
                Street = address.Street,
                HouseNumber = address.HouseNumber,
                ApartmentNumber = address.ApartmentNumber,
            };
        }
    }
}
