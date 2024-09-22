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
    public class DepartmentValidatorTests
    {
        private Validator _validator;
        //private SISContext _context;

        [TestInitialize]
        public void Setup()
        {
            _validator = new Validator();
            //_context = new SISContext();
        }
        //public void OnInit()
        //{
        //    var options = new DbContextOptionsBuilder<SISContext>()
        //        .UseInMemoryDatabase(databaseName: "DepartmentListDatabase" + Guid.NewGuid())
        //        .Options;
        //    //_context = new SISContext(options);
        //    //_context.Database.EnsureCreated();
        //    CSVHelper.GetDepartments();
        //}

        //[TestCleanup]
        //public void OnExit()
        //{
        //    //_context.Database.EnsureDeleted();
        //}

        [TestMethod]
        public void Validate_DepartmentName_TooShort_ShouldReturnError()
        {
            var department = new Department { DepartmentName = "CS" };
            var result = _validator.Validation_DepartmentName_LengthTooShort(department.DepartmentName);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_DepartmentName_WithSpecialCharacters_ShouldReturnError()
        {
            var department = new Department { DepartmentName = "Computer Science & Engineering" };
            var result = _validator.Validation_DepartmentName_Format(department.DepartmentName);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_DepartmentCode_LengthInvalid_ShouldReturnError()
        {
            var department = new Department { DepartmentCode = "CS12" };
            var result = _validator.Validation_DepartmentCode_Length(department.DepartmentCode);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_DepartmentCode_WithSpecialCharacters_ShouldReturnError()
        {
            var department = new Department { DepartmentCode = "CS123@" };
            var result = _validator.Validation_DepartmentName_Format(department.DepartmentCode);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_DepartmentCode_IsUnique_ShouldReturnError()
        {
            var department = new Department { DepartmentCode = "CS1234" };
            
            var result = _validator.Validation_DepartmentCode_IsUnique(department.DepartmentCode);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_DepartmentName_Required_ShouldReturnError()
        {
            var department = new Department { DepartmentName = null };
            var result = _validator.Validation_DepartmentName_IsEmpty(department.DepartmentName);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_DepartmentCode_Required_ShouldReturnError()
        {
            var department = new Department { DepartmentCode = null };
            var result = _validator.Validation_DepartmentCode_IsEmpty(department.DepartmentCode);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_DepartmentName_Empty_ShouldReturnError()
        {
            var department = new Department { DepartmentName = "" };
            var result = _validator.Validation_DepartmentName_IsEmpty(department.DepartmentName);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Validate_DepartmentCode_Empty_ShouldReturnError()
        {
            var department = new Department { DepartmentCode = "" };
            var result = _validator.Validation_DepartmentCode_IsEmpty(department.DepartmentCode);
            Assert.AreEqual(false, result);
        }
    }
}
