using AsmensRegistravimoSistemaI2.DTOs.Requests;
using AsmensRegistravimoSistemaI2.DTOs.Results;
using AsmensRegistravimoSistemaI2.Mappers.Interfaces;
using AsmensRegistravimoSistemaI2.Models.InformationControllerModels;

namespace AsmensRegistravimoSistemaI2.Mappers
{
    public class AddressMapper : IAddressMapper
    {
        // For getting Address from DB
        public AddressDTOResult Map(Address address)
        {
            return new AddressDTOResult
            {
                UserPIN = address.UserPIN,
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
                UserPIN = address.UserPIN,
                Town = address.Town,
                Street = address.Street,
                HouseNumber = address.HouseNumber,
                ApartmentNumber = address.ApartmentNumber,
            };
        }
    }
}
