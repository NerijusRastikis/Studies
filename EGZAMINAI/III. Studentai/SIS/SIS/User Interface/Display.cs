using Microsoft.Data.SqlClient.DataClassification;
using SIS.Database.Entities;
using SIS.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.User_Interface
{
    public class Display : IDisplay
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IStudentRepository studentRepository;
        private readonly ILectureRepository lectureRepository;

        public Display(IDepartmentRepository departmentRepository,
                       IStudentRepository studentRepository,
                       ILectureRepository lectureRepository)
        {
            this.departmentRepository = departmentRepository;
            this.studentRepository = studentRepository;
            this.lectureRepository = lectureRepository;
        }
        #region >>> Custom dialogs <<<
        public void Greeting()
        {
            Console.Clear();
            Console.WriteLine("Sveiki atvyke i Studentu Informacine Sistema!\n");
        }
        public void AddDepartment_Title()
        {
            Console.Clear();
            Console.WriteLine("P R I D E T I    K A T E D R A\n");
        }
        public void PressAnyKeyToContinue()
        {
            Console.WriteLine("Spauskite bet kuri mygtuka noredami testi...");
            Console.ReadLine();
        }
        #endregion
        public string ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("M E N I U\n");
            Console.WriteLine("1. Prideti katedra");
            Console.WriteLine("2. Prideti studentus/paskaitas i katedra");
            Console.WriteLine("3. Prideti paskaita");
            Console.WriteLine("4. Prideti studenta(-e)");
            Console.WriteLine("5. Perkelti studenta i kita katedra\n");
            Console.WriteLine("6. Atvaizduoti katedros studentus");
            Console.WriteLine("7. Atvaizduoti visas katedros paskaitas");
            Console.WriteLine("8. Atvaizduoti visas paskaitas pagal studenta\n");
            Console.WriteLine("0. Iseiti");
            return Console.ReadLine();
        }
        public string ShowMenu_AddLecturesOrStudents()
        {
            Console.Clear();
            Console.WriteLine("PPRIDETI PASKAITAS/STUDENTUS\n");
            Console.WriteLine("1. Prideti paskaita");
            Console.WriteLine("2. Prideti studenta(-e)\n");
            Console.WriteLine("0. Grizti");
            return Console.ReadLine();
        }
        public void AddTo_Department_Message()
        {
            Console.WriteLine("Prideta sekmingai!\n");
        }
        public void Updated_Student_Message()
        {
            Console.WriteLine("Pakeista sekmingai!\n");
        }

        #region >>> Tarpiniai klausimai <<<
        public string Add_LecturesToDepartment_Choice()
        {
            Console.Clear();
            Console.WriteLine("PRIDETI KATEDRA\n");
            Console.WriteLine("Norite prideti nauja paskaita ar is jau esamu?\n");
            Console.WriteLine("1. Nauja");
            Console.WriteLine("2. Jau esamu");
            return Console.ReadLine();
        }
        public string Select_Department_Choice()
        {
            Console.WriteLine();
            Console.Write("Pasirinkite katedra is saraso: ");
            return Console.ReadLine();
        }
        public string Select_Student_Choice()
        {
            Console.Write("Pasirinkite studenta(-e) is saraso: ");
            return Console.ReadLine();
        }
        #endregion
        #region >>> Informaciniai <<<
        public void Confirm_AddDepartment()
        {
            Console.WriteLine("Katedra su paskaita ir studentu sekmingai prideti!");
            Console.ReadLine();
        }
        #endregion

        #region >>> Add Department <<<
        public string Add_DepartmentCode()
        {
            Console.Clear();
            Console.WriteLine("PRIDETI KATEDRA\n");
            Console.Write("Katedros kodas: ");
            return Console.ReadLine();
        }
        public string Add_DepartmentName()
        {
            Console.Clear();
            Console.WriteLine("PRIDETI KATEDRA\n");
            Console.Write("Katedros pavadinimas: ");
            return Console.ReadLine();
        }
        #endregion
        #region >>> Add Student <<<
        public string Add_Student_StudentNumber()
        {
            Console.Write("Iveskite studento numeri: ");
            return Console.ReadLine();
        }
        public string Add_Student_DepartmentCode()
        {
            Console.Write("Iveskite studento katedros koda: ");
            return Console.ReadLine();
        }
        public string Add_Student_FirstName()
        {
            Console.Write("Iveskite studento varda: ");
            return Console.ReadLine();
        }
        public string Add_Student_LastName()
        {
            Console.Write("Iveskite studento pavarde: ");
            return Console.ReadLine();
        }
        public string Add_Student_Email()
        {
            Console.Write("Iveskite studento el. pasta: ");
            return Console.ReadLine();
        }
        #endregion
        #region >>> Add lecture <<<
        public string Add_Lecture_Name()
        {
            Console.Clear();
            Console.WriteLine("PRIDETI PASKAITA\n");
            Console.Write("Iveskite paskaitos pavadinima: ");
            return Console.ReadLine();
        }
        public string Add_Lecture_StartTime()
        {
            Console.Write("Iveskite paskaitos pradzios laika: ");
            return Console.ReadLine();
        }
        public string Add_Lecture_EndTime()
        {
            Console.Write("Iveskite paskaitos pabaigos laika: ");
            return Console.ReadLine();
        }
        public string Add_Lecture_DayOfWeek()
        {
            Console.Write("Iveskite paskaitos diena (angliskai) arba palikite tuscia lauka jei paskaita vyks kasdien: ");
            return Console.ReadLine().ToLower();
        }
        #endregion
        #region >>> Validatoriaus atsakymai <<<
        // VALIDATORIAUS ATSAKYMAI
        public void Display_Validation_DepartmentCode_Length(bool result)
        {
            if (!result)
            {
                Console.WriteLine("KLAIDA! Katedros kodas privalo buti 6 simboliai!");
            }
        }
        public void Display_Validation_DepartmentCode_Format(bool result)
        {
            if (!result)
            {
                Console.WriteLine("KLAIDA! Katedros kodas gali buti tik skaiciai ir raides!");
            }
        }
        public void Display_Validation_DepartmentCode_IsUnique(bool result)
        {
            if (!result)
            {
                Console.WriteLine("KLAIDA! Toks katedros kodas jau egzistuoja!");
            }
        }
        // KATEDROS PAVADINIMO PATIKROS
        public void Display_Validation_DepartmentName_LengthTooShort(bool result)
        {
            if (!result)
            {
                Console.WriteLine("KLAIDA! Katedros pavadinimas per trumpas!");
            }
        }
        public void Display_Validation_DepartmentName_LengthTooLong(bool result)
        {
            if (!result)
            {
                Console.WriteLine("KLAIDA! Katedros pavadinimas per ilgas!");
            }
        }
        public void Display_Validation_DepartmentName_Format(bool result)
        {
            if (!result)
            {
                Console.WriteLine("KLAIDA! Katedros pavadinima gali sudaryti tik raides ir skaiciai!");
            }
        }
        #endregion

        #region >>> PrintAll- <<<
        public void PrintAllLectures()
        {
            var lectures = lectureRepository.GetAll();
            int iterator = 1;

            Console.WriteLine("====== PASKAITU SARASO pradzia ======");
            Console.WriteLine();
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"{iterator}. Pavadinimas: {lecture.LectureName}");
                Console.WriteLine($"    Pradzios laikas: {lecture.LectureStartTime}");
                Console.WriteLine($"    Pabaigos laikas: {lecture.LectureEndTime}");
                Console.WriteLine($"    Kuria diena vyksta: {lecture.DayOfWeek}\n");
                iterator++;
            }
            Console.WriteLine("====== PASKAITU SARASO pabaiga ======");
            Console.WriteLine();
        }
        public void PrintAllDepartments()
        {
            var departments = departmentRepository.GetAll();
            int iterator = 1;

            Console.Clear();
            Console.WriteLine("====== KATEDRU SARASO pradzia ======");
            Console.WriteLine();
            foreach (var department in departments)
            {
                Console.WriteLine($"{iterator}. Pavadinimas: {department.DepartmentName}");
                Console.WriteLine($"    Kodas: {department.DepartmentCode}\n");
                iterator++;
            }
            Console.WriteLine();
            Console.WriteLine("====== KATEDRU SARASO pabaiga ======");
        }
        public void PrintAllStudents()
        {
            var students = studentRepository.GetAll();
            int iterator = 1;

            Console.WriteLine("====== STUDENTU SARASO pradzia ======");
            Console.WriteLine();
            foreach (var student in students)
            {
                Console.WriteLine($"{iterator}. Vardas: {student.FirstName}, Pavarde: {student.LastName}");
                Console.WriteLine($"    El. pastas: {student.Email}");
                Console.WriteLine($"    Priklauso katedrai (kodas): {student.DepartmentCode}");
                iterator++;
                Console.WriteLine();
            }
            Console.WriteLine("====== STUDENTU SARASO pabaiga ======");
        }
        #endregion

        #region >>> [MENU 2} Add lectures and students to department
        public string SelectDepartment()
        {
            PrintAllDepartments();
            Console.Write("Pasirinkite katedra is saraso: ");
            return Console.ReadLine();
        }
        public Department GetSelectedDepartment(string userInput)
        {
            int parsedInput = int.Parse(userInput);
            parsedInput--;
            Console.Clear();
            Console.WriteLine("Pasirinkta katedra\n");
            var departments = departmentRepository.GetAll().ToList();
            return departments[parsedInput];
        }
        public string WantToAddMoreLectures()
        {
            Console.WriteLine("Ar norite prideti viena paskaita?");
            return Console.ReadLine();
        }
        #endregion
        #region >>> [MENU 6] Show all department's students <<<
        public void PrintAllDepartmentStudents(string departmentCode)
        {
            int iterator = 1;
            Console.Clear();
            Console.WriteLine("PASIRINKTOS KATEDROS STUDENTU SARASAS\n");
            var selectedDepartment = departmentRepository.GetDepartmentWithStudents(departmentCode);
            foreach (var student in selectedDepartment.Students)
            {
                Console.WriteLine($"{iterator++}. Vardas: {student.FirstName}, pavarde: {student.LastName}, numeris: {student.StudentNumber}, el. pastas: {student.Email}");
                iterator++;
            }
            Console.WriteLine();
        }
        #endregion

    }
}
