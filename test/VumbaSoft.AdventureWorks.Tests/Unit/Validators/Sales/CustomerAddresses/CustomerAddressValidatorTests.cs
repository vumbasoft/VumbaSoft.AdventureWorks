using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class CustomerAddressValidatorTests : IDisposable
    {
        private CustomerAddressValidator validator;
        private TestingContext context;
        private CustomerAddress address;

        public CustomerAddressValidatorTests()
        {
            context = new TestingContext();
            validator = new CustomerAddressValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<CustomerAddress>().Add(address = ObjectsFactory.CreateCustomerAddress());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateCustomerAddressView(2)));
        }

        [Fact]
        public void CanCreate_ValidAddress()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateCustomerAddressView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateCustomerAddressView()));
        }

        [Fact]
        public void CanEdit_ValidAddress()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateCustomerAddressView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
