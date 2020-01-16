using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class EmployeepayhistoryValidatorTests : IDisposable
    {
        private EmployeepayhistoryValidator validator;
        private TestingContext context;
        private EmployeePayHistory employeepayhistory;

        public EmployeepayhistoryValidatorTests()
        {
            context = new TestingContext();
            validator = new EmployeepayhistoryValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<EmployeePayHistory>().Add(employeepayhistory = ObjectsFactory.CreateEmployeepayhistory());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateEmployeepayhistoryView(2)));
        }

        [Fact]
        public void CanCreate_ValidEmployeepayhistory()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateEmployeepayhistoryView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateEmployeepayhistoryView()));
        }

        [Fact]
        public void CanEdit_ValidEmployeepayhistory()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateEmployeepayhistoryView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
