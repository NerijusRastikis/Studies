using Apartments.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartments.Repositories
{
    public class ApartmentRepository
    {
        private readonly ApartmentsContext _context;

        public ApartmentRepository(ApartmentsContext context)
        {
            _context = context;
        }
        public Apartment AddApartment(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
            _context.SaveChanges();
            return apartment;
        }
        public Apartment GetAllByInstitutionIdWithFacilities()
    }
}
