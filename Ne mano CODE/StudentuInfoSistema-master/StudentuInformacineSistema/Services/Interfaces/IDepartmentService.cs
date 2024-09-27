using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentuInformacineSistema.Database.Entities;

namespace StudentuInformacineSistema.Services.Interfaces
{
    public interface IDepartmentService
    {
        bool CreateDepartament(Department departament);
        List<Department> GetDepartments();
        Department GetDepartmentByCode(string code);
        bool AddLectureToDepartmen(string departmentCode, string lectureName);
        

    }
}
