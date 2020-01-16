using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class EmployeeAddressValidatorTests : IDisposable
    {
        private EmployeeAddressValidator validator;
        private TestingContext context;
        private EmployeeAddress address;

        public EmployeeAddressValidatorTests()
        {
            context = new TestingContext();
            validator = new EmployeeAddressValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<EmployeeAddress>().Add(address = ObjectsFactory.CreateEmployeeAddress());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateEmployeeAddressView(2)));
        }

        [Fact]
        public void CanCreate_ValidAddress()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateEmployeeAddressView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateEmployeeAddressView()));
        }

        [Fact]
        public void CanEdit_ValidAddress()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateEmployeeAddressView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
