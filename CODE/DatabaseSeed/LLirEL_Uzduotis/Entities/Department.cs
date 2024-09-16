using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLirEL_Uzduotis.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }


        public List<Employee> Employees { get; set; } = new List<Employee>();
        public Manager Manager { get; set; }
    }
}
