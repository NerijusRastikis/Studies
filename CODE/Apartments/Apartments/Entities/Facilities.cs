using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartments.Entities
{
    public class Facilities
    {
        public int FacilitiesId { get; set; }
        public string Title { get; set; }

        //public int ApartmentId { get; set; }
        public List<Apartment> Apartments { get; set; } = new List<Apartment>();
    }
}
