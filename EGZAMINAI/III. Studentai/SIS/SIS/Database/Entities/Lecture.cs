using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Database.Entities
{
    public class Lecture
    {
        public int LectureId { get; set; }
        public string LectureName { get; set; }
        public TimeSpan LectureStartTime { get; set; }
        public TimeSpan LectureEndTime { get; set; }
        public string DayOfWeek { get; set; }

        
        public ICollection<Department> Departments { get; set; } = new List<Department>();
        public ICollection<LectureStudent> Students { get; set; } = new List<LectureStudent>();
    }

}
