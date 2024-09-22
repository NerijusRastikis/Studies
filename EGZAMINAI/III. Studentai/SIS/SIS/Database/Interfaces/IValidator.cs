namespace SIS.Database.Interfaces
{
    public interface IValidator
    {
        int AddDepartmentLectureChoiceValidation(string userInput);
        int GeneralMenuChoiceValidation(string userInput);
        int MenuChoiceValidation(string userInput);
        bool Validate_DepartmentCode(string departmentCode);
        bool Validate_DepartmentName(string departmentName);
        bool Validate_LectureName(string lectureName);
        bool Validate_LectureStartEndTime(string lectureStartTime, string lectureEndTime);
        bool Validate_StudentDepartment(string userInput);
        bool Validate_StudentEmail(string userInput);
        bool Validate_StudentNameOrSurname(string userInput);
        bool Validate_StudentNumber(string userInput);
        bool Validation_DepartmentCode_Format(string userInput);
        bool Validation_DepartmentCode_IsEmpty(string userInput);
        bool Validation_DepartmentCode_IsUnique(string userInput);
        bool Validation_DepartmentCode_Length(string userInput);
        bool Validation_DepartmentName_Format(string userInput);
        bool Validation_DepartmentName_IsEmpty(string userInput);
        bool Validation_DepartmentName_LengthTooLong(string userInput);
        bool Validation_DepartmentName_LengthTooShort(string userInput);
        bool Validation_LectureDayOfWeek_Validity(string userDayOfWeek);
        bool Validation_LectureName_IsEmpty(string userInput);
        bool Validation_LectureName_LengthTooLong(string userInput);
        bool Validation_LectureName_LengthTooShort(string userInput);
        bool Validation_LectureTime_IsEmpty(string userInput);
        bool Validation_LectureTime_OverlappingTimes(string userStartTime, string userEndTime);
        bool Validation_LectureTime_TimeFormat(string userInput);
        bool Validation_LectureTime_TimeLogic(string userInput1, string userInput2);
        bool Validation_StudentDepartment_IsEmpty(string userInput);
        bool Validation_StudentEmail_Format(string userInput);
        bool Validation_StudentEmail_IsEmpty(string userInput);
        bool Validation_StudentEmail_IsUnique(string userInput);
        bool Validation_StudentNameOrSurname_Format(string userInput);
        bool Validation_StudentNameOrSurname_IsEmpty(string userInput);
        bool Validation_StudentNameOrSurname_LengthTooLong(string userInput);
        bool Validation_StudentNameOrSurname_LengthTooShort(string userInput);
        bool Validation_StudentNumber_Format(string userInput);
        bool Validation_StudentNumber_IsUnique(string userInput);
        bool Validation_StudentNumber_Length(string userInput);
    }
}