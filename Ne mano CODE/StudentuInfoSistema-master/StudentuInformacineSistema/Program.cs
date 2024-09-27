using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentuInformacineSistema.Database.Repositories.Interfaces;
using StudentuInformacineSistema.Database.Repositories;
using StudentuInformacineSistema.Services.Interfaces;
using StudentuInformacineSistema.Services;

using StudentuInformacineSistema.UserInterface.Interfaces;

namespace StudentuInformacineSistema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studentsContext = new StudentsContext();

            IDepartmentRepository departmentRepository = new DepartmentRepository(studentsContext);
            ILectureRepository lectureRepository = new LectureRepository(studentsContext);
            IStudentRepository studentRepository = new StudentRepository(studentsContext);

            IDepartmentService departmentService = new DepartmentService(departmentRepository);
            ILectureService lectureService = new LectureService(lectureRepository);
            IStudentService studentService = new StudentService(studentRepository);

            IUserInterface userInterface = new UserInterface.UserInterface(departmentService, lectureService, studentService);

            //studentsContext.Database.EnsureDeleted();
            //studentsContext.Database.EnsureCreated();

            while (true)
            {
                userInterface.MainMenu();
            }

        }
    }
}
