using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Database.Entities
{
    public class LectureStudent
    {
        public int LectureId { get; set; }
        public int StudentNumber { get; set; }

        public Lecture Lecture { get; set; }
        public Student Student { get; set; }
    }
}
