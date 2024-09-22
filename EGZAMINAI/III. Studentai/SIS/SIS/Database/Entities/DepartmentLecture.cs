using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Database.Entities
{
    public class DepartmentLecture
    {
        public string DepartmentCode { get; set; }
        public int LectureId { get; set; }

        public Department Department { get; set; }
        public Lecture Lecture { get; set; }
    }
}
