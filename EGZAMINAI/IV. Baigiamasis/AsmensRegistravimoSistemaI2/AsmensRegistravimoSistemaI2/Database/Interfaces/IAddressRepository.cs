using AsmensRegistravimoSistemaI2.Models;

namespace AsmensRegistravimoSistemaI2.Database.Interfaces
{
    public interface IAddressRepository
    {
        Guid CreateAddress(Address address);
        Address? GetAddress(Guid id);
        bool DeleteAddress(Guid id);
        bool UpdateAddress(Address address);
    }
}