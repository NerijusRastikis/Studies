using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentuInformacineSistema.Database.Entities
{
    public class Department
    {
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();   
    }
}
