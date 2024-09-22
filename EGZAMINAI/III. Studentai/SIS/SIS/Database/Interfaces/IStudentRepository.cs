using SIS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Database.Interfaces
{
    public interface IStudentRepository
    {
        Student Create(Student student);
        Student Update(Student student);
        Student GetById(int studentNumber);
        IEnumerable<Student> GetAll();
        void Delete(int studentNumber);
    }
}
