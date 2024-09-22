using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using SIS.Database.Interfaces;
using SIS.Database.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SIS.Database.Services
{
    public class Validator : IValidator
    {
        private readonly IStudentRepository studentRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly ILectureRepository lectureRepository;

        public Validator(IStudentRepository studentRepository,
                        IDepartmentRepository departmentRepository,
                        ILectureRepository lectureRepository)
        {
            this.studentRepository = studentRepository;
            this.departmentRepository = departmentRepository;
            this.lectureRepository = lectureRepository;
        }

        public Validator()
        {
        }

        /* STRUKTURA
         * 
         * Metodai, prasidedantys Validation - smulkieji validatoriai, kurie gražina tik true/false
         * Metodai, prasidedantys Validate - smulkiųjų validatorių grupės, kurios grąžina kartu ir tekstą
         * 
         * Taipogi tai leidžia testuoti Validation, o Validate metodai lieka išvedimui
         * 
         */

        #region >>> Custom validations <<<
        public int MenuChoiceValidation(string userInput)
        {
            int output;
            if (int.TryParse(userInput, out output) && output >= 0 && output <= 8)
            {
                return output;
            }
            return 0;
        }
        public int AddDepartmentLectureChoiceValidation(string userInput)
        {
            int output;
            if (int.TryParse(Console.ReadLine(), out output) || (output == 1 || output == 2))
            {
                return output;
            }
            return 0;
        }
        public int GeneralMenuChoiceValidation(string userInput)
        {
            int output;
            if (int.TryParse(userInput, out output))
            {
                return output;
            }
            return 0;
        }
        #endregion

        #region >>> Student Validations <<<
        public bool Validation_StudentNameOrSurname_IsEmpty(string userInput)
        {
            if (userInput.IsNullOrEmpty())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Validation_StudentNameOrSurname_Format(string userInput)
        {
            // Naudoju Regex uztikrinti, kad butu tik raides (is interneto kodas)
            if (Regex.IsMatch(userInput, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Validation_StudentNameOrSurname_LengthTooShort(string userInput)
        {
            if (userInput.Length < 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Validation_StudentNameOrSurname_LengthTooLong(string userInput)
        {
            if (userInput.Length > 50)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Validation_StudentNumber_Format(string userInput)
        {
            if (Regex.IsMatch(userInput, @"^\d+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Validation_StudentNumber_Length(string userInput)
        {
            if (userInput.Length == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Validation_StudentNumber_IsUnique(string userInput)
        {
            //var studentList = studentRepository.GetAll();
            //bool emailExists = studentList.Any(s => s.StudentNumber == int.Parse(userInput));
            //return !emailExists;
            var studentList = studentRepository.GetAll();
            foreach (var student in studentList)
            {
                if (student.StudentNumber == int.Parse(userInput))
                {
                    return false;
                }
            }
            return true;
        }
        public bool Validation_StudentEmail_Format(string userInput)
        {
            if (Regex.IsMatch(userInput, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Validation_StudentEmail_IsEmpty(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Validation_StudentEmail_IsUnique(string userInput)
        {
            //var studentList = studentRepository.GetAll();
            //bool emailExists = studentList.Any(s => s.Email == userInput);
            //return !emailExists;
            var studentList = studentRepository.GetAll().ToList();
            foreach (var student in studentList)
            {
                if (student.Email == userInput)
                {
                    return false;
                }
            }
            return true;
        }
        // Pakartojau del skaitomumo - Validation_StudentEmail_IsEmpty yra tas pats,
        // tad buvo galima suglausti i viena metoda
        public bool Validation_StudentDepartment_IsEmpty(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Validate_StudentNameOrSurname(string userInput)
        {
            if (Validation_StudentNameOrSurname_IsEmpty(userInput) == false)
            {
                Console.WriteLine("KLAIDA! Studento vardas/pavarde negali buti tuscias laukas!");
                Console.ReadLine();
                return false;
            }
            else if (Validation_StudentNameOrSurname_Format(userInput) == false)
            {
                Console.WriteLine($"KLAIDA! \"{userInput}\"  varda turi sudaryti vien raides!");
                Console.ReadLine();
                return false;
            }
            else if (Validation_StudentNameOrSurname_LengthTooShort(userInput) == false)
            {
                Console.WriteLine($"KLAIDA! \"{userInput}\" vardas yra per trumpas!");
                Console.ReadLine();
                return false;
            }
            else if (Validation_StudentNameOrSurname_LengthTooLong(userInput) == false)
            {
                Console.WriteLine($"KLAIDA! \"{userInput}\" vardas yra per ilgas!");
                Console.ReadLine();
                return false;
            }
            else
            {
                Console.WriteLine($"\"{userInput}\" - sekmingai priimta!");
                Console.ReadLine();
                return true;
            }
        }
        public bool Validate_StudentNumber(string userInput)
        {
            if (Validation_StudentNumber_Format(userInput) == false)
            {
                Console.WriteLine($"KLAIDA! \"{userInput}\"  numeri turi sudaryti vien skaiciai!");
                Console.ReadLine();
                return false;
            }
            else if (Validation_StudentNumber_IsUnique(userInput) == false)
            {
                Console.WriteLine($"KLAIDA! \"{userInput}\" - jau egzistuoja!");
                Console.ReadLine();
                return false;
            }
            else if (Validation_StudentNumber_Length(userInput) == false)
            {
                Console.WriteLine($"KLAIDA! \"{userInput}\" privalo buti 8 skaiciai!");
                Console.ReadLine();
                return false;
            }
            else
            {
                Console.WriteLine($"\"{userInput}\" - sekmingai priimta!");
                Console.ReadLine();
                return true;
            }
        }
        public bool Validate_StudentEmail(string userInput)
        {
            if (Validation_StudentEmail_IsEmpty(userInput) == false)
            {
                Console.WriteLine("KLAIDA! El. pastas negali buti tuscias laukas!");
                Console.ReadLine();
                return false;
            }
            else if (Validation_StudentEmail_Format(userInput) == false)
            {
                Console.WriteLine($"KLAIDA! \"{userInput}\" el. pastas netinkamo formato!");
                Console.ReadLine();
                return false;
            }
            else if (Validation_StudentEmail_IsUnique(userInput) == false)
            {
                Console.WriteLine($"KLAIDA! \"{userInput}\" - el. pastas jau egzistuoja!");
                Console.ReadLine();
                return false;
            }
            else
            {
                Console.WriteLine($"\"{userInput}\" - sekmingai priimta!");
                Console.ReadLine();
                return true;
            }
        }
        public bool Validate_StudentDepartment(string userInput)
        {
            if (Validation_StudentDepartment_IsEmpty(userInput) == false)
            {
                Console.WriteLine("KLAIDA! Katedra negali buti tuscias laukas!");
                Console.ReadLine();
                return false;
            }
            else
            {
                Console.WriteLine($"\"{userInput}\" - sekmingai priimta!");
                Console.ReadLine();
                return true;
            }
        }
        #endregion
        #region >>> Department Validations <<<
        public bool Validation_DepartmentName_LengthTooShort(string userInput)
        {
            if (userInput.Length < 3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Validation_DepartmentName_LengthTooLong(string userInput)
        {
            if (userInput.Length > 100)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Validation_DepartmentName_IsEmpty(string userInput)
        {
            if (userInput.IsNullOrEmpty())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Validation_DepartmentName_Format(string userInput)
        {
            if (Regex.IsMatch(userInput, "^[a-zA-Z0-9]+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Validation_DepartmentCode_Length(string userInput)
        {
            if (userInput.Length != 6)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Validation_DepartmentCode_Format(string userInput)
        {
            if (Regex.IsMatch(userInput, @"^ [a - zA - Z0 - 9] +$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Validation_DepartmentCode_IsEmpty(string userInput)
        {
            if (userInput.IsNullOrEmpty())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Validation_DepartmentCode_IsUnique(string userInput)
        {
            //var departmentList = departmentRepository.GetAll();
            //bool departmentExists = departmentList.Any(s => s.DepartmentCode == userInput);
            //return !departmentExists;
            var departmentList = departmentRepository.GetAll().ToList();
            foreach (var department in departmentList)
            {
                if (department.DepartmentCode == userInput)
                {
                    return false;
                }
            }
            return true;
        }
        public bool Validate_DepartmentCode(string departmentCode)
        {
            if (Validation_DepartmentCode_Length(departmentCode) == false)
            {
                Console.WriteLine($"KLAIDA! \"{departmentCode}\" yra netinkamas katedros kodo ilgis!");
                Console.ReadLine();
                return false;
            }
            else if (Validation_DepartmentName_Format(departmentCode) == false)
            {
                Console.WriteLine($"KLAIDA! \"{departmentCode}\" yra netinkamas katedros kodo formatas!");
                Console.ReadLine();
                return false;
            }
            else if (Validation_DepartmentCode_IsUnique(departmentCode) == false)
            {
                Console.WriteLine($"KLAIDA! \"{departmentCode}\" jau egzistuoja!");
                Console.ReadLine();
                return false;
            }
            else
            {
                Console.WriteLine($"\"{departmentCode}\" - sekmingai priimta!");
                Console.ReadLine();
                return true;
            }
        }
        public bool Validate_DepartmentName(string departmentName)
        {
            if (Validation_DepartmentName_LengthTooShort(departmentName) == false)
            {
                Console.WriteLine($"KLAIDA! \"{departmentName}\" per trumpas!");
                Console.ReadLine();
                return false;
            }
            else if (Validation_DepartmentName_LengthTooLong(departmentName) == false)
            {
                Console.WriteLine($"KLAIDA! \"{departmentName}\" per ilgas!");
                Console.ReadLine();
                return false;
            }
            else if (Validation_DepartmentName_Format(departmentName) == false)
            {
                Console.WriteLine($"KLAIDA! \"{departmentName}\" netinkamo formato!");
                Console.ReadLine();
                return false;
            }
            else
            {
                Console.WriteLine($"\"{departmentName}\" - sekmingai priimta!");
                Console.ReadLine();
                return true;
            }
        }
        #endregion
        #region >>> Lecture Validations <<<
        public bool Validation_LectureName_IsEmpty(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Validation_LectureName_LengthTooShort(string userInput)
        {
            if (userInput.Length < 5)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Validation_LectureName_LengthTooLong(string userInput)
        {
            if (userInput.Length > 100)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Validation_LectureTime_IsEmpty(string userInput)
        {
            if (userInput.IsNullOrEmpty())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Validation_LectureTime_TimeFormat(string userInput)
        {
            var times = userInput.Split('-');
            foreach (var time in times)
            {
                var hoursAndMinutes = time.Split(':');
                if (int.Parse(hoursAndMinutes[0]) > 24)
                {
                    Console.WriteLine($"KLAIDA! \"{userInput}\" netinkamas laiko formatas! Turi buti HH:MM-HH:MM!");
                    return false;
                }
            }
            return true;
        }
        public bool Validation_LectureTime_TimeLogic(string userInput1, string userInput2)
        {
            // Kapoju laikus (string)
            // Du laikus HH:MM per bruksneli
            // Tada valandas ir minutes gaunu per dvitaski
            // Ir tuomet lyginu: jei pirmoji valanda didesne - klaida
            //                   jei valandos sutampa, bet minutes(1) didesne uz minutes(2) - klaida

            var tempTime1 = userInput1.Split(':');
            var timeH1 = int.Parse(tempTime1[0]);
            var timeM1 = int.Parse(tempTime1[1]);
            var tempTime2 = userInput2.Split(':');
            var timeH2 = int.Parse(tempTime2[0]);
            var timeM2 = int.Parse(tempTime2[1]);

            if (timeH1 > timeH2)
            {
                //Console.WriteLine($"KLAIDA! \"{userInput1}-{userInput2}\" netinkamas laiko formatas (prasideda veliau, nei pasibaigia)!");
                return false;
            }
            else if (timeH1 == timeH2 &&
                    timeM1 > timeM2)
            {
                //Console.WriteLine($"KLAIDA! \"{userInput1}-{userInput2}\" netinkamas laiko formatas (prasideda veliau, nei pasibaigia)!");
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Validation_LectureTime_OverlappingTimes(string userStartTime, string userEndTime)
        {
            var userStart = TimeSpan.Parse(userStartTime);
            var userEnd = TimeSpan.Parse(userEndTime);

            var lectureTimes = lectureRepository.GetAll();
            foreach (var lecture in lectureTimes)
            {
                var dbStart = lecture.LectureStartTime;
                var dbEnd = lecture.LectureEndTime;

                // True jei persikloja laikai
                if (userStart < dbEnd && userEnd > dbStart)
                {
                    Console.WriteLine($"Warning! Time overlaps with lecture: {lecture.LectureName}!");
                    return false;
                }
            }
            return true;
        }
        public bool Validation_LectureDayOfWeek_Validity(string userDayOfWeek)
        {
            List<string> days = new List<string>()
            {
                "monday", "tuesday", "wednesday", "thursday", "friday", "everyday"
            };
            foreach (var day in days)
            {
                if (day == userDayOfWeek)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Validate_LectureName(string lectureName)
        {
            if (Validation_LectureName_IsEmpty(lectureName) == false)
            {
                Console.WriteLine("KLAIDA! Paskaitos pavadinimas negali buti tuscias!");
                Console.ReadLine();
                return false;
            }
            else if (Validation_LectureName_LengthTooShort(lectureName) == false)
            {
                Console.WriteLine($"KLAIDA! \"{lectureName}\" per trumpas! Turi buti bent 5 simboliai!");
                Console.ReadLine();
                return false;
            }
            else if (Validation_LectureName_LengthTooLong(lectureName) == false)
            {
                Console.WriteLine($"KLAIDA! \"{lectureName}\" per ilgas! Turi buti iki 100 simboliu!");
                Console.ReadLine();
                return false;
            }
            else
            {
                Console.WriteLine($"\"{lectureName}\" - sekmingai priimta!");
                Console.ReadLine();
                return true;
            }
        }
        public bool Validate_LectureStartEndTime(string lectureStartTime, string lectureEndTime)
        {
            if (Validation_LectureTime_TimeLogic(lectureStartTime, lectureEndTime) == false)
            {
                Console.WriteLine($"KLAIDA! \"{lectureStartTime}\" - prasilenkia su laiko logika!");
                Console.ReadLine();
                return false;
            }
            else if (Validation_LectureTime_TimeFormat(lectureStartTime) == false)
            {
                Console.WriteLine($"KLAIDA! \"{lectureStartTime}\" netinkamas laiko formatas!");
                Console.ReadLine();
                return false;
            }
            else if (Validation_LectureTime_TimeLogic(lectureStartTime, lectureEndTime) == false)
            {
                Console.WriteLine($"KLAIDA! \"{lectureEndTime}\" - prasilenkia su laiko logika!");
                Console.ReadLine();
                return false;
            }
            else if (Validation_LectureTime_TimeFormat(lectureEndTime) == false)
            {
                Console.WriteLine($"KLAIDA! \"{lectureEndTime}\" netinkamas laiko formatas!");
                Console.ReadLine();
                return false;
            }
            else if (Validation_LectureTime_OverlappingTimes(lectureStartTime, lectureEndTime) == false)
            {
                Console.WriteLine($"KLAIDA! \"{lectureStartTime}\" laikas persidengia su kitu laiku!");
                Console.ReadLine();
                return false;
            }
            else
            {
                Console.WriteLine($"\"{lectureStartTime}-{lectureEndTime}\" - sekmingai priimtas!");
                Console.ReadLine();
                return true;
            }
        }
        #endregion
    }
}
