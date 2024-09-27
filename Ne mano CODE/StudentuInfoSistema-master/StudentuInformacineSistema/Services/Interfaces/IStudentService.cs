using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentuInformacineSistema.Database.Entities;

namespace StudentuInformacineSistema.Services.Interfaces
{
    public interface IStudentService
    {
        bool CreateStudent(Student student);
        List<Student> GetStudents();
        Student GetStudentById(int id);
        List<Student> GetStudentsByDepartmentCode(string code);
        bool AddDepartmentToStudent(int studentNumber, string departmentCode);
        bool UpdateStudent(Student student);
        bool AddLectureToStudent(int studentNumber, string lectureName);
    }
}
