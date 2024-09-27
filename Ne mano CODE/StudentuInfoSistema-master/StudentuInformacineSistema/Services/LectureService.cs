using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentuInformacineSistema.Services.Interfaces;
using StudentuInformacineSistema.Database.Repositories.Interfaces;
using StudentuInformacineSistema.Database.Entities;

namespace StudentuInformacineSistema.Services
{
    public class LectureService : ILectureService
    {
        private readonly ILectureRepository _lectureRepository;

        public LectureService(ILectureRepository lectureRepository)
        {
            _lectureRepository = lectureRepository;
        }
        public List<Lecture> GetLectures()
        {
            return _lectureRepository.GetLectures();
        }

        public Lecture GetLectureByName(string name)
        {
            return _lectureRepository.GetLectures().FirstOrDefault(x => x.LectureName == name);
        }

        public List<Lecture> GetLecturesByDepartment(string code)
        {
            return _lectureRepository.GetLecturesByDepartmentCode(code);
        }

        public List<Lecture> GetLecturesByStudent(int number)
        {
            return _lectureRepository.GetLecturesByStudentNumber(number);
        }

        public bool AddLectureToDepartment(string lectureName, string departmentCode)
        {
            _lectureRepository.UpdateLecture(lectureName, departmentCode);
            return true;
        }
        public bool CreateLecture(Lecture lecture)
        {
            if (!ValidateLecture(lecture))
            {
                return false;
            }

            // Patikriname ar paskaitos pavadinimas unikalus
            if (_lectureRepository.GetLectures().Any(l => l.LectureName == lecture.LectureName))
            {
                return false; 
            }

            return _lectureRepository.AddLecture(lecture);
        }
        private bool ValidateLecture(Lecture lecture)
        {
            return ValidateLectureName(lecture.LectureName) && ValidateLectureTime(lecture.LectureTime);
        }

        // Patikriname, kad butu mažiausiai 5 simboliai
        private bool ValidateLectureName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 5)
            {
                return false;
            }
            return true;
        }

        // Patikriname ar laikas atitinka realius laiko intervalus
        private bool ValidateLectureTime(string time)
        {
            if (string.IsNullOrWhiteSpace(time))
            {
                return false;
            }

            // Patikriname ar teisingas formatas
            if (TimeSpan.TryParse(time, out var parsedTime))
            {
                if (parsedTime.Hours >= 24 || parsedTime.Minutes >= 60)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
