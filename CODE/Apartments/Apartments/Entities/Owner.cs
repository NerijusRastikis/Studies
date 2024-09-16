using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartments.Entities
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }

        //public int InstitutionId { get; set; }
        public Institution Institution { get; set; }
    }
}
