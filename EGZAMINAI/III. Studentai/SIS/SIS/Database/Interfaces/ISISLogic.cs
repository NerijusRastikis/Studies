using SIS.Database.Entities;

namespace SIS.Database.Interfaces
{
    public interface ISISLogic
    {
        Lecture Add_NewLecture();
        void Exit();
        string Find_DepartmentCode_ByUserInput(string userInput);
        Department Handle_AddDepartment_Object();
        Lecture Handle_AddLectureQuestion(out string capturedChoice);
        Student Handle_AddStudent_Object();
        void Run();
        Lecture SelectLecture();
    }
}