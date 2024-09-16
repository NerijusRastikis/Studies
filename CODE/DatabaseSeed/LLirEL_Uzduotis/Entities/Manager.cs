using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLirEL_Uzduotis.Entities
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public Department Department { get; set; }
    }
}
