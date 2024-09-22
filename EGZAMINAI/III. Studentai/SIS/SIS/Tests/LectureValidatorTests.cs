using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIS.Database.Entities;
using SIS.Database.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tests
{
    [TestClass]
    public class LectureValidatorTests
    {
        private Validator _validator;

        [TestInitialize]
        public void Setup()
        {
            _validator = new Validator();
        }

        [TestMethod]
        public void Validate_LectureName_Required_ShouldReturnError()
        {
            var lecture = new Lecture { LectureName = null };
            var result = _validator.Validation_LectureName_IsEmpty(lecture.LectureName);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_LectureStartTime_Required_ShouldReturnError()
        {
            string lectureTime = null;
            var result = _validator.Validation_LectureTime_IsEmpty(lectureTime);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_LectureEndTime_Required_ShouldReturnError()
        {
            string lectureTime = null;
            var result = _validator.Validation_LectureTime_IsEmpty(lectureTime);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_LectureTimes_InvalidOverlap_ShouldReturnError()
        {
            string lectureStartTime = "25:00";
            string lectureEndTime = "26:30";
            var result1 = _validator.Validation_LectureTime_TimeFormat(lectureStartTime);
            var result2 = _validator.Validation_LectureTime_TimeFormat(lectureEndTime);
            Assert.AreEqual(false, result1);
            Assert.AreEqual(false, result2);
        }

        [TestMethod]
        public void Validate_LectureTimes_InvalidDuration_ShouldReturnError()
        {
            string lectureStartTime = "14:00";
            string lectureEndTime = "13:00";
            var result = _validator.Validation_LectureTime_TimeLogic(lectureStartTime, lectureEndTime);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_LectureName_TooLong_ShouldReturnError()
        {
            var lecture = new Lecture { LectureName = new string('A', 101) };
            var result = _validator.Validation_LectureName_LengthTooLong(lecture.LectureName);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_LectureName_TooShort_ShouldReturnError()
        {
            var lecture = new Lecture { LectureName = "Math" };
            var result = _validator.Validation_LectureName_LengthTooShort(lecture.LectureName);
            Assert.AreEqual(false, result);
        }
    }
}
