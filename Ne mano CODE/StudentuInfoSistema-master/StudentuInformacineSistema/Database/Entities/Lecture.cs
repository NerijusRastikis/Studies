using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentuInformacineSistema.Database.Entities
{
    public class Lecture
    {
        public string LectureName { get; set; }
        public string LectureTime { get; set; }

        public ICollection<Department> Departments { get; set; } = new List<Department>();
        public ICollection<Student> Students { get; set; }
    }
}
