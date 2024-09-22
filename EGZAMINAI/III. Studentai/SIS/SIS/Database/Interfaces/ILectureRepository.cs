using SIS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Database.Interfaces
{
    public interface ILectureRepository
    {
        Lecture Create(Lecture lecture);
        Lecture Update(Lecture lecture);
        Lecture GetById(int lectureId);
        IEnumerable<Lecture> GetAll();
        void Delete(int lectureId);
    }
}
