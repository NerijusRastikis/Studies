using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLirEL_Uzduotis.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }


        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Company> Companys { get; set; } = new List<Company>();
    }
}
