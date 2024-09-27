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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly StudentsContext _context;
        public DepartmentRepository(StudentsContext context)
        {
            _context = context;
        }
        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public List<Department> GetDepartments()
        {
            return _context.Departments.ToList();
        }
        public bool AddDepartmentLecture(string departmentCode, string lectureName)
        {
            var department = _context.Departments.Include(s => s.Lectures).FirstOrDefault(d => d.DepartmentCode == departmentCode);
            var lecture = _context.Lectures.FirstOrDefault(l => l.LectureName == lectureName);

            if (department != null && lecture != null)
            {
                if (department.Lectures == null)
                {
                    department.Lectures = new List<Lecture>();
                }

                if (!department.Lectures.Contains(lecture))
                {
                    department.Lectures.Add(lecture);
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
