using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartments.Entities
{
    public class Place
    {
        public int PlaceId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        //public int InstitutionId { get; set; }
        public List<Institution> Institutions { get; set; } = new List<Institution>();
    }
}
