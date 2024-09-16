using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLirEL_Uzduotis.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public int ProjectId { get; set; }


        public Department Department { get; set; }
        public List<Project> Projects { get; set; } = new List<Project>();
    }
}
