using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentuInformacineSistema.Database.Entities;

namespace StudentuInformacineSistema.Services.Interfaces
{
    public interface ILectureService
    {
        bool CreateLecture(Lecture lecture);
        List<Lecture> GetLectures();
        Lecture GetLectureByName(string code);
        List<Lecture> GetLecturesByDepartment(string code);
        List<Lecture> GetLecturesByStudent(int number);
        bool AddLectureToDepartment(string lectureName, string departmentCode);

    }
}
