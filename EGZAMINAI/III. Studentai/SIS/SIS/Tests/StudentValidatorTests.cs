using Microsoft.EntityFrameworkCore;
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
        private SISContext _context;

        [TestInitialize]
        public void Setup()
        {
            _validator = new Validator();
            _context = new SISContext();
        }
        public void OnInit()
        {
            var options = new DbContextOptionsBuilder<SISContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase" + Guid.NewGuid())
            .Options;

            _context = new SISContext(options);

            _context.Database.EnsureCreated();
        }
        public void OnExit()
        {
            _context.Database.EnsureDeleted();
        }

        public static List<Student> GetStudents()
        {
            var csv = File.ReadAllLines("Database\\Seed Files\\students.csv").Skip(1);
            var students = new List<Student>();
            foreach (var line in csv)
            {
                var capturedLine = line.Split(',');
                var student = new Student()
                {
                    FirstName = capturedLine[0],
                    LastName = capturedLine[1],
                    StudentNumber = int.Parse(capturedLine[2]),
                    Email = capturedLine[3],
                    DepartmentCode = capturedLine[4]
                };
                students.Add(student);
            }
            return students;
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
            var result = _validator.Validation_StudentNameOrSurname_LengthTooShort(student.FirstName);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_StudentName_TooLong_ShouldReturnError()
        {
            // Truko vieno Johnathon? - nes destytojo salygoje 45 simboliai, testas failino
            var student = new Student { FirstName = "JohnathonJohnathonJohnathonJohnathonJohnathonJohnathon", LastName = "Smith" };
            var result = _validator.Validation_StudentNameOrSurname_LengthTooLong(student.FirstName);
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
        public void Validate_StudentNumber_IsUnique_ShouldReturnError()
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
        public void Validate_StudentEmail_IsUnique_ShouldReturnError()
        {
            //var studentEmail = "alice.johnson@example.com";
            //var student = new Student { Email = "alice.johnson@example.com" };
            //var result = _validator.Validation_StudentEmail_IsUnique(student.Email);
            //Assert.AreEqual(false, result);

            var students = GetStudents();
            foreach (var student in students)
            {
                _context.Students.Add(student);
            }
            _context.SaveChanges();  // Commit seeded data to in-memory database

            // Act: Test if the email is unique (this email already exists in CSV)
            var studentEmail = "alice.johnson@example.com";
            var result = _validator.Validation_StudentEmail_IsUnique(studentEmail);

            // Assert: Email should not be unique (since it's in the CSV file)
            Assert.AreEqual(false, result);
        }
    }

}
