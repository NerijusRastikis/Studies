using SIS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Database.Interfaces
{
    public interface IDepartmentRepository
    {
        Department Create(Department department);
        Department Update(Department department);
        Department GetById(string departmentCode);
        IEnumerable<Department> GetAll();
        void Delete(string departmentCode);
        Department GetDepartmentWithStudents(string departmentCode);
    }
}
