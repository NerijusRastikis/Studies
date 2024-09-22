using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Database.Entities
{
    public class Student
    {
        public int StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DepartmentCode { get; set; }

        public Department Department { get; set; }
        public ICollection<LectureStudent> Lectures { get; set; } = new List<LectureStudent>();
    }
}
