using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class EmployeeValidatorTests : IDisposable
    {
        private EmployeeValidator validator;
        private TestingContext context;
        private Employee employee;

        public EmployeeValidatorTests()
        {
            context = new TestingContext();
            validator = new EmployeeValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<Employee>().Add(employee = ObjectsFactory.CreateEmployee());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateEmployeeView(2)));
        }

        [Fact]
        public void CanCreate_ValidEmployee()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateEmployeeView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateEmployeeView()));
        }

        [Fact]
        public void CanEdit_ValidEmployee()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateEmployeeView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
