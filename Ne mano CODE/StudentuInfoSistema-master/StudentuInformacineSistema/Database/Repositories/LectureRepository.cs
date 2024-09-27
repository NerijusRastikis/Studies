using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentuInformacineSistema.Database.Repositories.Interfaces;
using StudentuInformacineSistema.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace StudentuInformacineSistema.Database.Repositories
{
    public class LectureRepository : ILectureRepository
    {
        private readonly StudentsContext _context;
        public LectureRepository(StudentsContext context)
        {
            _context = context;
        }
        public bool AddLecture(Lecture lecture)
        {
            _context.Lectures.Add(lecture);
            _context.SaveChanges();
            return true;
        }
        public List<Lecture> GetLectures()
        {
            return _context.Lectures.ToList();
        }
        public Lecture GetLectureByName(string name)
        {
            return _context.Lectures.FirstOrDefault(x => x.LectureName == name);
        }
        public List<Lecture> GetLecturesByDepartmentCode(string code)
        {
            return _context.Lectures.Where(x => x.Departments.Any(d => d.DepartmentCode == code)).ToList();
        }
        public List<Lecture> GetLecturesByStudentNumber(int number)
        {
            return _context.Lectures.Where(x => x.Students.Any(s => s.StudentNumber == number)).ToList();
        }
        public bool UpdateLecture(string lectureName, string departmentCode)
        {
            Lecture lecture = _context.Lectures.FirstOrDefault(x => x.LectureName == lectureName);
            if (lecture == null)
            {
                return false;
            }
            Department department = _context.Departments.FirstOrDefault(x => x.DepartmentCode == departmentCode);
            if (department == null)
            {
                return false;
            }
            lecture.Departments.Add(department);
            _context.SaveChanges();
            return true;
        }
    }
}
