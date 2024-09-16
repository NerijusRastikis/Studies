using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartments.Entities
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public int Title { get; set; }
        public string Type { get; set; }
        public int RoomsCount { get; set; }
        public decimal DailyPrice { get; set; }
        public DateTime ReservationDateFrom { get; set; }
        public DateTime ReservationDateTo { get; set; }

        //public int InstitutionId { get; set; }
        public Institution Institution { get; set; } = new Institution();
        //public int FacilityId { get; set; }
        public List<Facilities> Facilities { get; set; } = new List<Facilities>();
        //public int ServiceId {  get; set; }
        public List<Services> Services { get; set; } = new List<Services>();
        //public int ClientId {  get; set; }
        public List<Client> Clients { get; set; } = new List<Client>();
    }
}
