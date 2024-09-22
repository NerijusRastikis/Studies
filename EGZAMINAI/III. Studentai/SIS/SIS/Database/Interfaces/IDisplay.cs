using SIS.Database.Entities;

namespace SIS.Database.Interfaces
{
    public interface IDisplay
    {
        void AddDepartment_Title();
        void AddTo_Department_Message();
        string Add_DepartmentCode();
        string Add_DepartmentName();
        string Add_LecturesToDepartment_Choice();
        string Add_Lecture_DayOfWeek();
        string Add_Lecture_EndTime();
        string Add_Lecture_Name();
        string Add_Lecture_StartTime();
        string Add_Student_DepartmentCode();
        string Add_Student_Email();
        string Add_Student_FirstName();
        string Add_Student_LastName();
        string Add_Student_StudentNumber();
        void Confirm_AddDepartment();
        void Display_Validation_DepartmentCode_Format(bool result);
        void Display_Validation_DepartmentCode_IsUnique(bool result);
        void Display_Validation_DepartmentCode_Length(bool result);
        void Display_Validation_DepartmentName_Format(bool result);
        void Display_Validation_DepartmentName_LengthTooLong(bool result);
        void Display_Validation_DepartmentName_LengthTooShort(bool result);
        Department GetSelectedDepartment(string userInput);
        void Greeting();
        void PressAnyKeyToContinue();
        void PrintAllDepartments();
        void PrintAllDepartmentStudents(string departmentCode);
        void PrintAllLectures();
        void PrintAllStudents();
        string SelectDepartment();
        string Select_Department_Choice();
        string Select_Student_Choice();
        string ShowMenu();
        string ShowMenu_AddLecturesOrStudents();
        void Updated_Student_Message();
        string WantToAddMoreLectures();
    }
}