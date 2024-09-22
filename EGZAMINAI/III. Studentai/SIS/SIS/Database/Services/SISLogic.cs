using Microsoft.Identity.Client;
using SIS.Database.Entities;
using SIS.Database.Interfaces;
using SIS.User_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Database.Services
{
    public class SISLogic : ISISLogic
    {
        private readonly Display display;
        private readonly Validator validator;
        private readonly IDepartmentRepository departmentRepository;
        private readonly ILectureRepository lectureRepository;
        private readonly IStudentRepository studentRepository;

        public SISLogic(Display display, Validator validator,
                        IDepartmentRepository departmentRepository,
                        ILectureRepository lectureRepository,
                        IStudentRepository studentRepository)
        {
            this.display = display;
            this.validator = validator;
            this.departmentRepository = departmentRepository;
            this.lectureRepository = lectureRepository;
            this.studentRepository = studentRepository;
        }
        public void Run()
        {
            while (true)
            {
                var choice = display.ShowMenu();
                switch (validator.MenuChoiceValidation(choice))
                {
                    case 1:
                        string capturedLectureChoice;
                        display.AddDepartment_Title();
                        var newDepartment = Handle_AddDepartment_Object();
                        // Jei paskaita paimta ne nauja, tuomet nereiks taikyti create metodo
                        // Kad tai uzregistruoti sukuriamas out (kuris siuncia atsakyma ar nauja paskaita, ar ne)
                        if (newDepartment == null)
                        {
                            break;
                        }
                        Console.Clear();
                        display.AddDepartment_Title();
                        var newLecture = Handle_AddLectureQuestion(out capturedLectureChoice);
                        if (newLecture == null)
                        {
                            break;
                        }
                        Console.Clear();
                        display.AddDepartment_Title();
                        var newStudent = Handle_AddStudent_Object();
                        if (newStudent == null)
                        {
                            break;
                        }
                        if (capturedLectureChoice == "1")
                        {
                            lectureRepository.Create(newLecture);
                        }
                        else
                        {
                            newDepartment.Lectures.Add(newLecture);
                            newDepartment.Students.Add(newStudent);
                            departmentRepository.Create(newDepartment);
                        }
                        studentRepository.Create(newStudent);
                        display.Confirm_AddDepartment();
                        display.PressAnyKeyToContinue();
                        break;
                    case 2:
                        Console.Clear();
                        var userInput = display.SelectDepartment();
                        var selectedDepartment = display.GetSelectedDepartment(userInput);
                        var createdLecture = Add_NewLecture();
                        var createdStudent = Handle_AddStudent_Object();
                        selectedDepartment.Lectures.Add(createdLecture);
                        selectedDepartment.Students.Add(createdStudent);
                        departmentRepository.Update(selectedDepartment);
                        display.AddTo_Department_Message();
                        display.PressAnyKeyToContinue();
                        break;
                    case 3:
                        var userInput1 = display.SelectDepartment();
                        var selectedDepartment1 = display.GetSelectedDepartment(userInput1);
                        var createdLecture1 = Add_NewLecture();
                        selectedDepartment1.Lectures.Add(createdLecture1);
                        display.AddTo_Department_Message();
                        display.PressAnyKeyToContinue();
                        break;
                    case 4:
                        var createdStudent2 = Handle_AddStudent_Object();
                        var userInput2 = display.SelectDepartment();
                        var selectedDepartment2 = display.GetSelectedDepartment(userInput2);
                        var selectedLecture2 = SelectLecture();
                        selectedDepartment2.Students.Add(createdStudent2);
                        selectedDepartment2.Lectures.Add(selectedLecture2);
                        display.AddTo_Department_Message();
                        display.PressAnyKeyToContinue();
                        break;
                    case 5:
                        var userInput4 = display.SelectDepartment();
                        var selectedDepartment4 = display.GetSelectedDepartment(userInput4);
                        display.PrintAllStudents();
                        var selectedStudentuserChoice4 = display.Select_Student_Choice();
                        var studentList4 = studentRepository.GetAll().ToList();
                        Console.Clear();
                        var selectedStudent4 = studentRepository.GetById(studentList4[int.Parse(selectedStudentuserChoice4) - 1].StudentNumber);
                        selectedStudent4.Department = selectedDepartment4;
                        display.Updated_Student_Message();
                        display.PressAnyKeyToContinue();
                        break;
                    case 6:
                        display.PrintAllDepartments();
                        display.PrintAllDepartmentStudents(Find_DepartmentCode_ByUserInput(display.Select_Department_Choice()));
                        display.PressAnyKeyToContinue();
                        break;
                    case 7:
                        display.PrintAllDepartments();
                        var markedDepartmentCode = Find_DepartmentCode_ByUserInput(display.Select_Department_Choice());
                        var markedDepartment = departmentRepository.GetById(markedDepartmentCode);
                        Console.WriteLine();
                        foreach (var lecture in markedDepartment.Lectures)
                        {
                            Console.WriteLine($"Paskaitos pavadinimas: {lecture.LectureName}");
                            Console.WriteLine($"Paskaitos laikas: {lecture.LectureStartTime}-{lecture.LectureEndTime}");
                            Console.WriteLine($"Paskaitos dažnumas: {lecture.DayOfWeek}\n");
                        }
                        display.PressAnyKeyToContinue();
                        break;
                    case 8:
                        Console.Clear();
                        display.PrintAllStudents();
                        var selectedStudentFromList = display.Select_Student_Choice();
                        var studentList = studentRepository.GetAll().ToList();
                        Console.Clear();
                        var selectedStudent = studentRepository.GetById(studentList[int.Parse(selectedStudentFromList) - 1].StudentNumber);
                        Console.WriteLine($"Vardas: {selectedStudent.FirstName}, Pavarde: {selectedStudent.LastName}");
                        int iterator = 0;
                        var lecturesList = lectureRepository.GetAll().ToList();
                        foreach (var lecture in lecturesList)
                        {
                            foreach (var studentLecture in selectedStudent.Lectures.ToList())
                            {
                                if (studentLecture.LectureId == lecture.LectureId)
                                {
                                    Console.WriteLine($"{++iterator}. Pavadinimas: {lecture.LectureName}");
                                    Console.WriteLine($"Paskaitos laikas: {lecture.LectureStartTime}-{lecture.LectureEndTime}");
                                    Console.WriteLine($"Paskaitos daznumas: {lecture.DayOfWeek}\n");
                                }
                            }
                        }
                        display.PressAnyKeyToContinue();
                        break;
                    case 0:
                        Exit();
                        break;
                    default:
                        throw new Exception("Kazkas ivyko ne taip");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void Exit()
        {
            Console.Clear();
            Console.WriteLine("Iseinama...");
            Environment.Exit(0);
        }
        public string Find_DepartmentCode_ByUserInput(string userInput)
        {
            int choice;
            if (int.TryParse(userInput, out choice))
            {
                List<Department> departments = departmentRepository.GetAll().ToList();
                choice--;
                var selectedDepartment = departments[choice];
                return selectedDepartment.DepartmentCode;
            }
            else
            {
                throw new Exception("Neteisinga ivestis.");
            }
        }
        public Department Handle_AddDepartment_Object()
        {
            var newDepartmentName = display.Add_DepartmentName();
            if (validator.Validate_DepartmentName(newDepartmentName) == false)
            {
                return null;
            }
            var newDepartmentCode = display.Add_DepartmentCode();
            if (validator.Validate_DepartmentCode(newDepartmentCode) == false)
            {
                return null;
            }
            var newDepartment = new Department()
            {
                DepartmentCode = newDepartmentCode,
                DepartmentName = newDepartmentName
            };
            return newDepartment;
        }
        public Lecture Handle_AddLectureQuestion(out string capturedChoice)
        {
            capturedChoice = display.Add_LecturesToDepartment_Choice();
            if (validator.GeneralMenuChoiceValidation(capturedChoice) == 1)
            {
                return Add_NewLecture();
            }
            else if (validator.GeneralMenuChoiceValidation(capturedChoice) == 2)
            {
                return SelectLecture();
            }
            else
            {
                Console.WriteLine("KLAIDA! Tokio pasirinkimo nera!");
                return null;
            }
        }
        public Student Handle_AddStudent_Object()
        {
            var newStudentNumber = display.Add_Student_StudentNumber();
            if (validator.Validate_StudentNumber(newStudentNumber) == false)
            {
                return null;
            }
            var newStudentFirstName = display.Add_Student_FirstName();
            if (validator.Validate_StudentNameOrSurname(newStudentFirstName) == false)
            {
                return null;
            }
            var newStudentLastName = display.Add_Student_LastName();
            if (validator.Validate_StudentNameOrSurname(newStudentLastName) == false)
            {
                return null;
            }
            var newStudentEmail = display.Add_Student_Email();
            if (validator.Validate_StudentEmail(newStudentEmail) == false)
            {
                return null;
            }
            var newStudentDepartmentCode = display.Add_Student_DepartmentCode();
            if (validator.Validate_StudentDepartment(newStudentDepartmentCode) == false)
            {
                return null;
            }
            var newStudent = new Student()
            {
                StudentNumber = int.Parse(newStudentNumber),
                FirstName = newStudentFirstName,
                LastName = newStudentLastName,
                Email = newStudentEmail,
                DepartmentCode = newStudentDepartmentCode
            };
            return newStudent;
        }
        public Lecture Add_NewLecture()
        {
            var newLectureName = display.Add_Lecture_Name();
            if (validator.Validation_LectureName_IsEmpty(newLectureName) == false)
            {
                return null;
            }
            else if (validator.Validation_LectureName_LengthTooShort(newLectureName) == false)
            {
                return null;
            }
            else if (validator.Validation_LectureName_LengthTooLong(newLectureName) == false)
            {
                return null;
            }
            var newLectureStartTime = display.Add_Lecture_StartTime();
            var newLectureEndTime = display.Add_Lecture_EndTime();
            if (validator.Validate_LectureStartEndTime(newLectureStartTime, newLectureEndTime) == false)
            {
                return null;
            }
            var newLectureDayOfWeek = display.Add_Lecture_DayOfWeek();
            if (validator.Validation_LectureDayOfWeek_Validity(newLectureDayOfWeek) == false)
            {
                return null;
            }
            var newLecture = new Lecture()
            {
                LectureName = newLectureName,
                LectureStartTime = TimeSpan.Parse(newLectureStartTime),
                LectureEndTime = TimeSpan.Parse(newLectureEndTime),
                DayOfWeek = newLectureDayOfWeek
            };
            return newLecture;
        }
        public Lecture SelectLecture()
        {
            display.PrintAllLectures();
            Console.Write("Pasirinkite paskaita is saraso: ");
            string capturedLecture = Console.ReadLine();
            int selectedLectureNumber = validator.GeneralMenuChoiceValidation(capturedLecture);
            selectedLectureNumber--;
            var lectures = lectureRepository.GetAll().ToList();
            var selectedLecture = lectures[selectedLectureNumber];
            return selectedLecture;
        }
    }
}
