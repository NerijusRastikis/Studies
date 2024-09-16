using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartments.Entities
{
    public class Institution
    {
        public int InstitutionId { get; set; }
        public string Title { get; set; }

        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

        //public int ApartmentId {  get; set; }
        public List<Apartment> Apartments { get; set; } = new List<Apartment>();
        //public int PlaceId { get; set; }
        public Place Place { get; set; }
    }
}
