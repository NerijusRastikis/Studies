using Microsoft.IdentityModel.Tokens;
using SIS.Database.Interfaces;
using SIS.Database.Repositories;
using SIS.Database.Services;
using SIS.User_Interface;

namespace SIS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new SISContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            IStudentRepository studentRepository = new StudentRepository(context);
            IDepartmentRepository departmentRepository = new DepartmentRepository(context);
            ILectureRepository lectureRepository = new LectureRepository(context);

            var display = new Display(departmentRepository, studentRepository, lectureRepository);
            var validator = new Validator(studentRepository, departmentRepository, lectureRepository);

            var sis = new SISLogic(display, validator, departmentRepository, lectureRepository, studentRepository);

            sis.Run();
        }
    }
}
