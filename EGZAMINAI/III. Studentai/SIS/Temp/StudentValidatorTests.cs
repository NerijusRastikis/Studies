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
    public class StudentValidatorTests
    {
        private Validator _validator;

        [TestInitialize]
        public void Setup()
        {
            _validator = new Validator();
        }

        [TestMethod]
        public void Validate_StudentName_WithInvalidCharacters_ShouldReturnError()
        {
            var student = new Student { FirstName = "Jo1n", LastName = "Smith" };
            var result = _validator.Validation_StudentNameOrSurname_Format(student.FirstName);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_StudentName_TooShort_ShouldReturnError()
        {
            var student = new Student { FirstName = "J", LastName = "Smith" };
            var result = _validator.Validation_StudentNameOrSurname_Format(student.FirstName);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_StudentName_TooLong_ShouldReturnError()
        {
            var student = new Student { FirstName = "JohnathonJohnathonJohnathonJohnathonJohnathon", LastName = "Smith" };
            var result = _validator.Validation_StudentNameOrSurname_Format(student.FirstName);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_StudentLastName_WithInvalidCharacters_ShouldReturnError()
        {
            var student = new Student { FirstName = "John", LastName = "Sm!th" };
            var result = _validator.Validation_StudentNameOrSurname_Format(student.LastName);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_StudentNumber_LengthTooShort_ShouldReturnError()
        {
            var student = new Student { StudentNumber = 1234567 };
            var studentNumberToString = student.StudentNumber.ToString();
            var result = _validator.Validation_StudentNumber_Length(studentNumberToString);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_StudentNumber_WithLetters_ShouldReturnError()
        {
            // Kitaip neiseina istestuoti, nes mano StudentNumber yra int tipo
            var studentNumber = "1234ABCD";
            var result = _validator.Validation_StudentNumber_Format(studentNumber);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_StudentNumber_AlreadyExists_ShouldReturnError()
        {
            var student = new Student { StudentNumber = 12345678 };
            var studentNumberToString = student.StudentNumber.ToString();
            var result = _validator.Validation_StudentNumber_IsUnique(studentNumberToString);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_StudentEmail_InvalidFormat_ShouldReturnError()
        {
            var student = new Student { Email = "john.smithexample.com" };
            var result = _validator.Validation_StudentEmail_Format(student.Email);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_StudentEmail_MissingDomain_ShouldReturnError()
        {
            var student = new Student { Email = "john.smith@" };
            var result = _validator.Validation_StudentEmail_Format(student.Email);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_StudentEmail_MissingUsername_ShouldReturnError()
        {
            var student = new Student { Email = "@example.com" };
            var result = _validator.Validation_StudentEmail_Format(student.Email);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_StudentEmail_MissingDomainEnd_ShouldReturnError()
        {
            var student = new Student { Email = "john.smith@example" };
            var result = _validator.Validation_StudentEmail_Format(student.Email);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_StudentEmail_MissingEndWithDot_ShouldReturnError()
        {
            var student = new Student { Email = "john.smith@example." };
            var result = _validator.Validation_StudentEmail_Format(student.Email);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_StudentEmail_Required_ShouldReturnError()
        {
            var student = new Student { Email = null };
            var result = _validator.Validation_StudentEmail_IsEmpty(student.Email);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_StudentDepartment_Required_ShouldReturnError()
        {
            var student = new Student { DepartmentCode = null };
            var result = _validator.Validation_StudentDepartment_IsEmpty(student.DepartmentCode);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_StudentName_Empty_ShouldReturnError()
        {
            var student = new Student { FirstName = "", LastName = "Smith" };
            var result = _validator.Validation_StudentNameOrSurname_IsEmpty(student.FirstName);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_StudentName_Null_ShouldReturnError()
        {
            var student = new Student { FirstName = null, LastName = "Smith" };
            var result = _validator.Validation_StudentNameOrSurname_IsEmpty(student.FirstName);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_StudentEmail_UniqueConstraint_ShouldReturnError()
        {
            var studentEmail = "alice.johnson@example.com";
            var student = new Student { Email = "alice.johnson@example.com" };
            var result = _validator.Validation_StudentEmail_IsUnique(student.Email);
            Assert.AreEqual(false, result);
        }
    }

}
