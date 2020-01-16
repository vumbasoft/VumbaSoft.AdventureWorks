using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class EmployeedepartmenthistoryValidatorTests : IDisposable
    {
        private EmployeedepartmenthistoryValidator validator;
        private TestingContext context;
        private EmployeeDepartmentHistory employeedepartmenthistory;

        public EmployeedepartmenthistoryValidatorTests()
        {
            context = new TestingContext();
            validator = new EmployeedepartmenthistoryValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<EmployeeDepartmentHistory>().Add(employeedepartmenthistory = ObjectsFactory.CreateEmployeedepartmenthistory());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateEmployeedepartmenthistoryView(2)));
        }

        [Fact]
        public void CanCreate_ValidEmployeedepartmenthistory()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateEmployeedepartmenthistoryView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateEmployeedepartmenthistoryView()));
        }

        [Fact]
        public void CanEdit_ValidEmployeedepartmenthistory()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateEmployeedepartmenthistoryView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
