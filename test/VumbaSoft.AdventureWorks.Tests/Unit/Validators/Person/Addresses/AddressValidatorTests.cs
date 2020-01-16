using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class AddressValidatorTests : IDisposable
    {
        private AddressValidator validator;
        private TestingContext context;
        private Address address;

        public AddressValidatorTests()
        {
            context = new TestingContext();
            validator = new AddressValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<Address>().Add(address = ObjectsFactory.CreateAddress());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateAddressView(2)));
        }

        [Fact]
        public void CanCreate_ValidAddress()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateAddressView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateAddressView()));
        }

        [Fact]
        public void CanEdit_ValidAddress()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateAddressView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
