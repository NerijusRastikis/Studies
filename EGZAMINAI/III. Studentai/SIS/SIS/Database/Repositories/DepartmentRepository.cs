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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly SISContext _context;

        public DepartmentRepository(SISContext context)
        {
            _context = context;
        }
        public Department Create(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return department;
        }
        public Department Update(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
            return department;
        }
        public Department GetById(string departmentCode)
        {
            return _context.Departments
                .Include(d => d.Lectures)
                .Include(d => d.Students)
                .FirstOrDefault(d => d.DepartmentCode == departmentCode);
        }
        public IEnumerable<Department> GetAll()
        {
            return _context.Departments
                .Include(d => d.Lectures)
                .Include(d => d.Students)
                .ToList();
        }
        public void Delete(string departmentCode)
        {
            var department = _context.Departments.Find(departmentCode);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
        }
        public Department GetDepartmentWithStudents(string departmentCode)
        {
            return _context.Departments
                .Include(d => d.Students)
                .FirstOrDefault(d => d.DepartmentCode == departmentCode);
        }

    }
}
