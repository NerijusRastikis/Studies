using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentuInformacineSistema.Database.Entities;
using StudentuInformacineSistema.Services.Interfaces;
using StudentuInformacineSistema.Database.Repositories.Interfaces;
using System.Text.RegularExpressions;

namespace StudentuInformacineSistema.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public bool CreateStudent(Student student)
        {
            if (!ValidateStudent(student))
            {
                return false;
            }

            _studentRepository.AddStudent(student);
            return true;
        }
        public bool UpdateStudent(Student student) 
        {
            if (!ValidateStudent(student))
            {
                return false;
            }

            _studentRepository.UpdateStudent(student);
            return true;
        }
        public List<Student> GetStudents()
        {
            return _studentRepository.GetStudents();
        }
        public Student GetStudentById(int id)
        {
            return _studentRepository.GetStudent(id);
        }
        public List<Student> GetStudentsByDepartmentCode(string code)
        {
            return _studentRepository.GetStudents().Where(s => s.DepartmentCode == code).ToList();
        }
        public bool AddDepartmentToStudent(int studentNumber, string departmentCode)
        {
            Student student = _studentRepository.GetStudent(studentNumber);
            if (student == null)
            {
                return false;
            }
            student.DepartmentCode = departmentCode;
            _studentRepository.UpdateStudent(student);
            return true;
        }
        public bool AddLectureToStudent(int studentNumber, string lectureName)
        {
            _studentRepository.AddStudentLecture(studentNumber, lectureName);
            return true;
        }
        // Validacija studento sukūrimui ir atnaujinimui
        private bool ValidateStudent(Student student)
        {
            // FirstName validacija
            if (string.IsNullOrWhiteSpace(student.FirstName) ||
                !Regex.IsMatch(student.FirstName, @"^[a-zA-Z]+$") ||
                student.FirstName.Length < 2 || student.FirstName.Length > 50)
            {
                return false; 
            }
            // LastName validacija
            if (string.IsNullOrWhiteSpace(student.LastName) ||
                !Regex.IsMatch(student.LastName, @"^[a-zA-Z]+$") ||
                student.LastName.Length < 2 || student.LastName.Length > 50)
            {
                return false; 
            }
            // StudentNumber validacija
            if (student.StudentNumber.ToString().Length != 8 || !Regex.IsMatch(student.StudentNumber.ToString(), @"^\d+$"))
            {
                return false; 
            }
            // Email validacija
            if (string.IsNullOrWhiteSpace(student.Email) ||
                !Regex.IsMatch(student.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return false; 
            }

            return true;
        }

    }
}
