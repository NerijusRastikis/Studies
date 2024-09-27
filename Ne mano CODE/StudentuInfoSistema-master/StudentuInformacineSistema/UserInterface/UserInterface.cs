using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentuInformacineSistema.Services.Interfaces;
using StudentuInformacineSistema.UserInterface.Interfaces;
using StudentuInformacineSistema.Database.Entities;

namespace StudentuInformacineSistema.UserInterface
{
    public class UserInterface : IUserInterface
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILectureService _lectureService;
        private readonly IStudentService _studentService;

        public UserInterface(IDepartmentService departmentService, ILectureService lectureService, IStudentService studentService)
        {
            _departmentService = departmentService;
            _lectureService = lectureService;
            _studentService = studentService;
        }
        public void MainMenu()
        {
            Console.Clear();
            PrintHeader();
            ShowMenu();

            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    var department = CreateDepartment();
                    if ( department == null)
                    {
                        break;
                    }
                    AddStudentsOrExistLecturesToDepartment(department);
                    break;
                case "2":
                    AddStudentsAndLecturesToExistDepartment();
                    break;
                case "3":
                    var lecture3 = CreateLecture();
                    if (lecture3 == null)
                    {
                        break;
                    }
                    var choosedDepartment3 = ChooseDepartment();
                    AddLectureToDepartment(choosedDepartment3, lecture3);
                    break;
                case "4":
                    var student4 = CreateStudent();
                    if (student4 == null)
                    {
                        break;
                    }
                    var choosedDepartment4 = ChooseDepartment();
                    AddStudentToDepartment(choosedDepartment4, student4);
                    AddExistLectureToStudent(student4.StudentNumber);
                    Console.ReadKey();
                    break;
                case "5":
                    var student5 = ChooseStudent();
                    var choosedDepartment5 = ChooseDepartment();
                    UpdateStudentDepartment(choosedDepartment5, student5);
                    break;
                case "6":
                    ShowStudentsByDepartment();
                    break;
                case "7":
                    ShowLecturesByDepartment();
                    break;
                case "8":
                    ShowLecturesByStudent();
                    break;
                case "9":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Neteisingas pasirinkimas");
                    break;
            }
        }
        private string CreateDepartment()
        {
            Console.Clear();
            PrintHeader();
            var department = new Department();
            Console.WriteLine("Įveskite naujo departamento kodą:");
            department.DepartmentCode = Console.ReadLine();

            Console.WriteLine("Įveskite departamento pavadinimą:");
            department.DepartmentName = Console.ReadLine();

            var check = _departmentService.CreateDepartament(department);

            if (check)
            {
                Console.WriteLine($"Departamentas {department.DepartmentCode} sėkmingai sukurtas");
            }
            else
            {
                Console.WriteLine("Departamento sukurti nepavyko, patikrinkite ar įvedėte teisingus duomenis");
                Console.ReadKey();
                department.DepartmentCode = null;
                return department.DepartmentCode;
            }
            Console.ReadKey();

            return department.DepartmentCode;
        }
        private Lecture CreateLecture()
        {
            Console.Clear();
            PrintHeader();
            var lecture = new Lecture();
            Console.WriteLine("Įveskite naujos paskaitos pavadinimą:");
            lecture.LectureName = Console.ReadLine();

            Console.WriteLine("Įveskite paskaitos laiką:");
            lecture.LectureTime = Console.ReadLine();

            var check = _lectureService.CreateLecture(lecture);

            if (check)
            {
                Console.WriteLine($"Paskaita {lecture.LectureName} sukurtas sėkmingai");
            }
            else
            {
                Console.WriteLine("Paskaitos sukurti nepavyko, patikrinkite ar įvedėte teisingus duomenis");
                Console.ReadKey();
                lecture = null;
                return lecture;
            }
            Console.ReadKey();
            return lecture;
        }
        private Student CreateStudent()
        {
            Console.Clear();
            PrintHeader();
            var student = new Student();
            Console.WriteLine("Įveskite naujo studento unikalų numerį:");
            student.StudentNumber = int.TryParse(Console.ReadLine(), out int result) ? result : 0;

            Console.WriteLine("Įveskite studento pavardę:");
            student.FirstName = Console.ReadLine();

            Console.WriteLine("Įveskite studento pavardę");
            student.LastName = Console.ReadLine();

            Console.WriteLine("Įveskite studento el. paštą:");
            student.Email = Console.ReadLine();

            var check = _studentService.CreateStudent(student);

            if (check)
            {
                Console.WriteLine("Studentas sukurtas sėkmingai");
            }
            else
            {
                Console.WriteLine("Studento sukurti nepavyko, patikrinkite ar įvedėte teisingus duomenis");
                Console.ReadKey();
                student = null;
                return student;
            }
            Console.ReadKey();
            return student;
        }
        private int AddStudentToDepartment(string departmentCode, Student student)
        {
            student.DepartmentCode = departmentCode;

            var check = _studentService.UpdateStudent(student);

            if (check)
            {
                Console.WriteLine($"Studentas Nr. {student.StudentNumber} pridėtas prie {departmentCode} departamento ");
            }
            else
            {
                Console.WriteLine("Studento pridėti nepavyko, patikrinkite ar įvedėte teisingus duomenis");
            }
            Console.ReadKey();
            return student.StudentNumber;
        }
        private void AddLectureToDepartment(string departmentCode, Lecture lecture)
        {
            var check = _lectureService.AddLectureToDepartment(lecture.LectureName, departmentCode);

            if (check)
            {
                Console.WriteLine($"Paskaita {lecture.LectureName} priskirta departamentui {departmentCode}");
            }
            else
            {
                Console.WriteLine("Paskaitos priskirti nepavyko, patikrinkite ar įvedėte teisingus duomenis");
            }
            Console.ReadKey();
        }
        private void AddExistLectureToStudent(int studentNumber)
        {
            Console.Clear();
            PrintHeader();
            var lectures = _lectureService.GetLectures();
            Console.WriteLine($"Pasirinkite paskaitą, kurią norite pridėti studentui {studentNumber}:");
            Console.WriteLine();
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"{lecture.LectureName} {lecture.LectureTime}");
            }
            Console.WriteLine();
            Console.Write("Įveskite paskaitos pavadinimą, kurią norite pasirinkti: ");
            var enteredLectureName = Console.ReadLine();
            var choosedLecture = _studentService.AddLectureToStudent(studentNumber, enteredLectureName);
            if (choosedLecture == null)
            {
                Console.WriteLine("Paskaitos priskirti nepavyko, patikrinkite ar įvedėte teisingus duomenis");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Paskaita sėkmingai pridėta studentui Nr. {studentNumber}");
                Console.ReadKey();
            }
        }
        private void AddExistLectureToDepartment(string departmentCode)
        {
            Console.Clear();
            PrintHeader();
            var lectures = _lectureService.GetLectures();
            Console.WriteLine($"Pasirinkite paskaitą, kurią norite pridėti departamentui {departmentCode}:");
            Console.WriteLine();
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"{lecture.LectureName} {lecture.LectureTime}");
            }
            Console.WriteLine();
            Console.Write("Įveskite paskaitos pavadinimą, kurią norite pasirinkti: ");
            var enteredLectureName = Console.ReadLine();
            var choosedLecture = _lectureService.AddLectureToDepartment(enteredLectureName, departmentCode);
            if (choosedLecture == null)
            {
                Console.WriteLine("Paskaitos priskirti nepavyko, patikrinkite ar įvedėte teisingus duomenis");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Paskaita sėkmingai pridėta departamentui {departmentCode}");
                Console.ReadKey();
            }
        }
        private Student ChooseStudent()
        {
            Console.Clear();
            PrintHeader();
            var students = _studentService.GetStudents();
            var studentNumber = 0;
            foreach (var student in students)
            {
                Console.WriteLine($"{student.StudentNumber} {student.FirstName} {student.LastName}");
            }
            Console.WriteLine("Įveskite norimą pasirinkti studento numerį iš sąrašo:");
            var enteredStudentNumber = int.TryParse(Console.ReadLine(), out int result) ? result : 0;
            var choosedstudent = _studentService.GetStudentById(enteredStudentNumber);
            if (choosedstudent == null)
            {
                Console.WriteLine("Studento su tokiu numeriu nėra");
                Console.ReadKey();
                return null;
            }
            return choosedstudent;
        }
        private string ChooseDepartment()
        {
            Console.Clear();
            PrintHeader();
            var departments = _departmentService.GetDepartments();
            var departmentCode = "";
            foreach (var department in departments)
            {
                Console.WriteLine($"{department.DepartmentCode} {department.DepartmentName}");
            }
            Console.WriteLine();
            Console.WriteLine("Įveskite norimą pasirinkti departamento kodą iš sarašo:");
            var enteredDepartmentCode = Console.ReadLine();
            var choosedDepartment = _departmentService.GetDepartmentByCode(enteredDepartmentCode);
            if (choosedDepartment == null)
            {
                Console.WriteLine("Departamento su tokiu kodu nėra");
                Console.ReadKey();
                return null;
            }
            return choosedDepartment.DepartmentCode;
        }
        private Lecture ChooseLecture()
        {
            Console.Clear();
            PrintHeader();
            var lectures = _lectureService.GetLectures();
            var lectureName = "";
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"{lecture.LectureName} {lecture.LectureTime}");
            }
            Console.WriteLine();
            Console.WriteLine("Įveskite norimą pasirinkti paskaitos pavadinimą iš sąrašo:");
            var enteredLectureName = Console.ReadLine();
            var choosedLecture = _lectureService.GetLectureByName(enteredLectureName);
            if (choosedLecture == null)
            {
                Console.WriteLine("Paskaitos su tokiu pavadinimu nėra");
                Console.ReadKey();
                return null;
            }
            return choosedLecture;
        }
        private void ShowStudentsByDepartment()
        {
            var departmentCode = ChooseDepartment();
            if (departmentCode == null)
            {
                return;
            }
            var students = _studentService.GetStudentsByDepartmentCode(departmentCode);
            foreach (var student in students)
            {
                Console.WriteLine($"{student.StudentNumber} {student.FirstName} {student.LastName}");
            }
            Console.ReadKey();
        }
        private void ShowLecturesByDepartment()
        {
            var departmentCode = ChooseDepartment();
            if (departmentCode == null)
            {
                return;
            }
            var lectures = _lectureService.GetLecturesByDepartment(departmentCode);
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"{lecture.LectureName} {lecture.LectureTime}");
            }
            Console.ReadKey();
        }
        private void ShowLecturesByStudent()
        {
            var student = ChooseStudent();
            if (student == null)
            {
                return;
            }
            var lectures = _lectureService.GetLecturesByStudent(student.StudentNumber);
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"{lecture.LectureName} {lecture.LectureTime}");
            }
            Console.ReadKey();
        }
        private void AddStudentsAndLecturesToExistDepartment()
        {
            Console.Clear();
            PrintHeader();
            var choosedDepartment = ChooseDepartment();
            if (choosedDepartment == null)
            {
                return;
            }
            while (true)
            {
                Console.Clear();
                PrintHeader();
                Console.WriteLine($"1. Pridėti naują studentą prie pasirinkto departamento {choosedDepartment}");
                Console.WriteLine($"2. Pridėti naują paskaitą prie pasirinkto departamento {choosedDepartment}");
                Console.WriteLine("3. Grįžti į pagrindinį meniu");
                Console.WriteLine();
                Console.Write("Įveskite pasirinkimą: ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":           
                        var student = CreateStudent();
                        AddStudentToDepartment(choosedDepartment, student);
                        break;
                    case "2":
                        var lecture = CreateLecture();
                        AddLectureToDepartment(choosedDepartment, lecture);
                        break;
                        case "3":
                        break;
                    default:
                        Console.WriteLine("Neteisingas pasirinkimas");
                        break;
                }
                if (option == "3")
                {
                    break;
                }
            }
        }
        private void AddStudentsOrExistLecturesToDepartment(string department)
        {
            while (true)
            {
                Console.Clear();
                PrintHeader();
                Console.WriteLine($"1. Pridėti naują studentą prie naujo departamento {department}");
                Console.WriteLine($"2. Pridėti egzistuojančią paskaitą prie naujo departamento {department}");
                Console.WriteLine("3. Grįžti į pagrindinį meniu");
                Console.WriteLine();
                Console.Write("Įveskite pasirinkimą: ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        var student = CreateStudent();
                        AddStudentToDepartment(department, student);
                        break;
                    case "2":
                        AddExistLectureToDepartment(department);
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Neteisingas pasirinkimas");
                        break;
                }
                if (option == "3")
                {
                    break;
                }
            }
        }
        private void UpdateStudentDepartment(string departmentCode, Student student)
        {
            var check = _studentService.AddDepartmentToStudent(student.StudentNumber, departmentCode);
            if (check)
            {
                Console.WriteLine($"Studentas Nr. {student.StudentNumber} perkeltas į {departmentCode} departamentą");
            }
            else
            {
                Console.WriteLine("Studento perkelti nepavyko");
            }
            Console.ReadKey();
        }
        private void ShowMenu()
        {
            Console.WriteLine("1. Sukurti naują departamentą, pridėti studentus, paskaitas");
            Console.WriteLine("2. Pridėti studentus/paskaitas į egzistuojantį departamentą");
            Console.WriteLine("3. Sukurti paskaitą ir jai priskirti departamentą ");
            Console.WriteLine("4. Sukurti studentą ir pridėti prie egzistuojančio departamento ir priskirti egzistuojančias paskaitas");
            Console.WriteLine("5. Perkelti studentą į kitą departamentą");
            Console.WriteLine("6. Rodyti visus departamento studentus");
            Console.WriteLine("7. Rodyti visas departamento paskaitas");
            Console.WriteLine("8. Rodyti visas paskaitas pagal studentą");
            Console.WriteLine("9. Uždaryti programą");
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.Write("Įveskite pasirinkimą: "); 
        }

        private void PrintHeader()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("========================================");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("|      STUDENTU INFORMACINE SISTEMA     |");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("========================================");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
