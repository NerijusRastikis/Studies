using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentuInformacineSistema.Services.Interfaces;
using StudentuInformacineSistema.Database.Entities;
using StudentuInformacineSistema.Database.Repositories.Interfaces;
using System.Text.RegularExpressions;

namespace StudentuInformacineSistema.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public bool CreateDepartament(Department department)
        {
            if (!ValidateDepartament(department))
            {
                return false;
            }

            // Patikriname ar departamentas turi unikalu kodą
            if (_departmentRepository.GetDepartments().Any(d => d.DepartmentCode == department.DepartmentCode))
            {
                return false; 
            }

            _departmentRepository.AddDepartment(department);
            return true;
        }

        private bool ValidateDepartament(Department department)
        {
            if (!ValidateDepartamentName(department.DepartmentName) || !ValidateDepartamentCode(department.DepartmentCode))
            {
                return false;
            }
            return true;
        }

        // Patikriname departamento pavadinimas ne mažiau 3 ir nedaugiau 100 simbolių
        private bool ValidateDepartamentName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 3 || name.Length > 100)
            {
                return false;
            }
            return true;
        }

        // Patikriname ar departamento kodas atitinka reikalavimus
        private bool ValidateDepartamentCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code) || code.Length != 6 || !Regex.IsMatch(code, @"^[a-zA-Z0-9]+$"))
            {
                return false;
            }
            return true;
        }

        public List<Department> GetDepartments()
        {
            return _departmentRepository.GetDepartments();
        }

        public Department GetDepartmentByCode(string code)
        {
            return _departmentRepository.GetDepartments().FirstOrDefault(x => x.DepartmentCode == code);
        }

        public bool AddLectureToDepartmen(string departmentCode, string lectureName)
        {
            _departmentRepository.AddDepartmentLecture(departmentCode, lectureName);
            return true;
        }
    }


}
