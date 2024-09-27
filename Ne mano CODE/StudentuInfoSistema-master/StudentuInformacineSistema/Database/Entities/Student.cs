using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentuInformacineSistema.Database.Entities
{
    public class Student
    {
        public int StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? DepartmentCode { get; set; }

        // Navigacine savybes
        public Department Department { get; set; } 
        // Inicializuojame, kad nebutu null
        public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
        
    }
}
