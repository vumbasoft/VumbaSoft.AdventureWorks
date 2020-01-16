using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class DepartmentValidatorTests : IDisposable
    {
        private DepartmentValidator validator;
        private TestingContext context;
        private Department department;

        public DepartmentValidatorTests()
        {
            context = new TestingContext();
            validator = new DepartmentValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<Department>().Add(department = ObjectsFactory.CreateDepartment());
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
            validator.Dispose();
        }

        [Fact]
        public void CanCreate_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanCreate(ObjectsFactory.CreateDepartmentView(2)));
        }

        [Fact]
        public void CanCreate_ValidDepartment()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateDepartmentView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateDepartmentView()));
        }

        [Fact]
        public void CanEdit_ValidDepartment()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateDepartmentView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
