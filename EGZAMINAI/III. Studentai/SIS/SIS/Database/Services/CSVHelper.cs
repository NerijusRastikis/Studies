using SIS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Database.Services
{
    public static class CSVHelper
    {
        #region >> Get Entities <<
        public static List<Lecture> GetLectures()
        {
            int increment = -1;
            var csv = File.ReadAllLines("Database\\Seed Files\\lectures.csv").Skip(1);
            var lectures = new List<Lecture>();
            foreach (var line in csv)
            {
                var capturedLine = line.Split(',');
                var lecture = new Lecture()
                {
                    LectureId = increment--,
                    LectureName = capturedLine[0],
                    LectureStartTime = TimeSpan.Parse(capturedLine[1]),
                    LectureEndTime = TimeSpan.Parse(capturedLine[2]),
                    DayOfWeek = capturedLine[3]
                };
                lectures.Add(lecture);
            }
            return lectures;
        }
        public static List<Department> GetDepartments()
        {
            var csv = File.ReadAllLines("Database\\Seed Files\\departments.csv").Skip(1);
            var departments = new List<Department>();
            foreach (var line in csv)
            {
                var capturedLine = line.Split(',');
                var department = new Department()
                {
                    DepartmentCode = capturedLine[0],
                    DepartmentName = capturedLine[1]
                };
                departments.Add(department);
            }
            return departments;
        }
        public static List<Student> GetStudents()
        {
            var csv = File.ReadAllLines("Database\\Seed Files\\students.csv").Skip(1);
            var students = new List<Student>();
            foreach (var line in csv)
            {
                var capturedLine = line.Split(',');
                var student = new Student()
                {
                    FirstName = capturedLine[0],
                    LastName = capturedLine[1],
                    StudentNumber = int.Parse(capturedLine[2]),
                    Email = capturedLine[3],
                    DepartmentCode = capturedLine[4]
                };
                students.Add(student);
            }
            return students;
        }
        #endregion
        #region >> Get Contents from Cross Tables << 
        public static List<DepartmentLecture> GetDepartmentLectures()
        {
            var csv = File.ReadAllLines("Database\\Seed Files\\department_lectures.csv").Skip(1);
            var departments = GetDepartments();
            var lectures = GetLectures();
            var departmentLectures = new List<DepartmentLecture>();

            foreach (var line in csv)
            {
                var capturedLine = line.Split(',');
                var departmentCode = capturedLine[0];
                var lectureName = capturedLine[1];

                var department = departments.FirstOrDefault(d => d.DepartmentCode == departmentCode);
                var lecture = lectures.FirstOrDefault(l => l.LectureName == lectureName);

                if (department != null && lecture != null)
                {
                    departmentLectures.Add(new DepartmentLecture
                    {
                        DepartmentCode = departmentCode,
                        LectureId = lecture.LectureId
                    });
                }
            }

            return departmentLectures;
        }

        public static List<LectureStudent> GetStudentLectures()
        {
            var csv = File.ReadAllLines("Database\\Seed Files\\student_lectures.csv").Skip(1);
            var students = GetStudents();
            var lectures = GetLectures();
            var studentLectures = new List<LectureStudent>();

            foreach (var line in csv)
            {
                var capturedLine = line.Split(',');
                var studentNumber = int.Parse(capturedLine[0]);
                var lectureName = capturedLine[1];

                var student = students.FirstOrDefault(s => s.StudentNumber == studentNumber);
                var lecture = lectures.FirstOrDefault(l => l.LectureName == lectureName);

                if (student != null && lecture != null)
                {
                    studentLectures.Add(new LectureStudent
                    {
                        StudentNumber = studentNumber,
                        LectureId = lecture.LectureId
                    });
                }
            }

            return studentLectures;
        }


        #endregion
    }
}
