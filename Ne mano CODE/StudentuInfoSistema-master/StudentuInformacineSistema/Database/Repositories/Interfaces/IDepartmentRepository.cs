using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentuInformacineSistema.Database.Entities;

namespace StudentuInformacineSistema.Database.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        void AddDepartment(Department department);
        List<Department> GetDepartments();
        bool AddDepartmentLecture(string departmentCode, string lectureName);
    }
}
