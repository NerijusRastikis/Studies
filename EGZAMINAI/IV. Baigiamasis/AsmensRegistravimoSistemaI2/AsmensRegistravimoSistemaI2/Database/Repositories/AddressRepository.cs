using AsmensRegistravimoSistemaI2.Database.Interfaces;
using AsmensRegistravimoSistemaI2.Models;

namespace AsmensRegistravimoSistemaI2.Database.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ARSDbContext _context;

        public AddressRepository(ARSDbContext context)
        {
            _context = context;
        }
        public Guid CreateAddress(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return address.Id;
        }
        public Address? GetAddress(Guid id)
        {
            return _context.Addresses.FirstOrDefault(x => x.Id == id);
        }
    }
}
