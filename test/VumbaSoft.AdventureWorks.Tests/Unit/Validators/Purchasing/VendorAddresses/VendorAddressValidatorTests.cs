using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class VendorAddressValidatorTests : IDisposable
    {
        private VendorAddressValidator validator;
        private TestingContext context;
        private VendorAddress address;

        public VendorAddressValidatorTests()
        {
            context = new TestingContext();
            validator = new VendorAddressValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<VendorAddress>().Add(address = ObjectsFactory.CreateVendorAddress());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateVendorAddressView(2)));
        }

        [Fact]
        public void CanCreate_ValidAddress()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateVendorAddressView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateVendorAddressView()));
        }

        [Fact]
        public void CanEdit_ValidAddress()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateVendorAddressView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
