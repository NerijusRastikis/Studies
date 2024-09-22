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
    public class LectureRepository : ILectureRepository
    {
        private readonly SISContext _context;

        public LectureRepository(SISContext context)
        {
            _context = context;
        }

        public Lecture Create(Lecture lecture)
        {
            _context.Lectures.Add(lecture);
            _context.SaveChanges();
            return lecture;
        }

        public Lecture Update(Lecture lecture)
        {
            _context.Lectures.Update(lecture);
            _context.SaveChanges();
            return lecture;
        }

        public Lecture GetById(int lectureId)
        {
            return _context.Lectures
                .Include(l => l.Students)
                .FirstOrDefault(l => l.LectureId == lectureId);
        }

        public IEnumerable<Lecture> GetAll()
        {
            return _context.Lectures
                .Include(l => l.Students)
                .ToList();
        }

        public void Delete(int lectureId)
        {
            var lecture = _context.Lectures.Find(lectureId);
            if (lecture != null)
            {
                _context.Lectures.Remove(lecture);
                _context.SaveChanges();
            }
        }
    }
}
