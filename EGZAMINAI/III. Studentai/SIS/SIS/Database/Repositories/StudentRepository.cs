using Microsoft.EntityFrameworkCore;
using SIS.Database.Entities;
using SIS.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Database.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SISContext _context;

        public StudentRepository(SISContext context)
        {
            _context = context;
        }
        public Student Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }
        public Student Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return student;
        }
        public Student GetById(int studentNumber)
        {
            return _context.Students
                .Include(s => s.Lectures)
                .FirstOrDefault(s => s.StudentNumber == studentNumber);
        }
        public IEnumerable<Student> GetAll()
        {
            return _context.Students
                .Include(s => s.Lectures)
                .ToList();
        }
        public void Delete(int studentNumber)
        {
            var student = _context.Students.Find(studentNumber);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
