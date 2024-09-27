using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentuInformacineSistema.Database.Entities;
using StudentuInformacineSistema.Database.Repositories.Interfaces;

namespace StudentuInformacineSistema.Database.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentsContext _context;
        public StudentRepository(StudentsContext studentsContext)
        {
            _context = studentsContext;
        }
        public bool AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return true;
        }
        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
        }
        public Student GetStudent(int id)
        {
            return _context.Students.FirstOrDefault(s => s.StudentNumber == id);
        }
        public bool UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return true;
        }
        public bool AddStudentLecture(int studentNumber, string lectureName)
        {
            var student = _context.Students.Include(s => s.Lectures).FirstOrDefault(s => s.StudentNumber == studentNumber);
            var lecture = _context.Lectures.FirstOrDefault(l => l.LectureName == lectureName);

            if (student != null && lecture != null)
            {
                if (student.Lectures == null)
                {
                    student.Lectures = new List<Lecture>();
                }

                if (!student.Lectures.Contains(lecture))
                {
                    student.Lectures.Add(lecture);
                    _context.SaveChanges();
                    return true; 
                }
            }
            return false; 
        }
    }
}
