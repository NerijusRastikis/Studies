using StudentuInformacineSistema.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentuInformacineSistema
{
    public static class CSVDataService
    {
        public static List<Department> GetDepartments()
        {
            var csv = File.ReadAllLines("Database/InitialData/departments.csv");
            var departments = new List<Department>();
            foreach (var line in csv.Skip(1))
            {
                var values = line.Split(',');
                var department = new Department
                {
                    DepartmentCode = values[0],
                    DepartmentName = values[1]
                };
                departments.Add(department);
            }
            return departments;
        }
        public static List<Student> GetStudents()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());

            var csv = File.ReadAllLines("../../../Database/InitialData/students.csv");
            var students = new List<Student>();
            foreach (var line in csv.Skip(1))
            {
                var values = line.Split(',');
                var student = new Student
                {
                    StudentNumber = int.TryParse(values[0], out int number) ? number : 0,
                    FirstName = values[1],
                    LastName = values[2],
                    Email = values[3],
                    DepartmentCode = values[4]
                };
                students.Add(student);
            }
            return students;
        }
        public static List<Lecture> GetLectures()
        {
            var csv = File.ReadAllLines("../../../Database/InitialData/lectures.csv");
            var lectures = new List<Lecture>();
            foreach (var line in csv.Skip(1))
            {
                var values = line.Split(',');
                var lecture = new Lecture
                {
                    LectureName = values[0],
                    LectureTime = values[1],
                };
                lectures.Add(lecture);
            }
            return lectures;
        }
        public static List<object> GetDepartmentLectures()
        {
            var csv = File.ReadAllLines("../../../Database/InitialData/department_lectures.csv");
            var departmentLectures = new List<object>();
            foreach (var line in csv.Skip(1))
            {
                var values = line.Split(',');
                var DepartmentCode = values[0];
                var LectureName = values[1];
                departmentLectures.Add(new { DepartmentsDepartmentCode = DepartmentCode, LecturesLectureName = LectureName });
            }
            return departmentLectures;
        }
        public static List<object> GetStudentLectures()
        {
            var csv = File.ReadAllLines("../../../Database/InitialData/student_lectures.csv");
            var studentLectures = new List<object>();
            foreach (var line in csv.Skip(1))
            {
                var values = line.Split(',');
                var StudentNumber = int.Parse(values[0]);
                var LectureName = values[1];
                studentLectures.Add(new { StudentsStudentNumber = StudentNumber, LecturesLectureName = LectureName });
            }
            return studentLectures;
        }
    }
}
