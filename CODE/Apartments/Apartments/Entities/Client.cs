using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartments.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FullName { get; set; }
        public int PersonalCode { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }

        //public int ApartmentId { get; set; }
        public List<Apartment> Apartments { get; set; } = new List<Apartment>();
    }
}
