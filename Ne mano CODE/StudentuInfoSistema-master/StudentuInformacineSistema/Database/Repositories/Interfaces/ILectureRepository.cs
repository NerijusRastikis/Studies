using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentuInformacineSistema.Database.Entities;

namespace StudentuInformacineSistema.Database.Repositories.Interfaces
{
    public interface ILectureRepository
    {
        bool AddLecture(Lecture lecture);
        bool UpdateLecture(string lectureName, string departmentCode);
        List<Lecture> GetLectures();
        Lecture GetLectureByName(string name);
        List<Lecture> GetLecturesByDepartmentCode(string code);
        List<Lecture> GetLecturesByStudentNumber(int number);
    }
}
