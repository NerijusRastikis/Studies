using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentuInformacineSistema.Database.Entities;

namespace StudentuInformacineSistema.Database.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        bool AddStudent(Student student);
        List<Student> GetStudents();
        Student GetStudent(int id);
        bool UpdateStudent(Student student);
        bool AddStudentLecture(int studentNumber, string lectureName);
    }
}
