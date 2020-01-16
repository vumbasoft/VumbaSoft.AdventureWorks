using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class VendorContactValidatorTests : IDisposable
    {
        private VendorContactValidator validator;
        private TestingContext context;
        private VendorContact contact;

        public VendorContactValidatorTests()
        {
            context = new TestingContext();
            validator = new VendorContactValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<VendorContact>().Add(contact = ObjectsFactory.CreateVendorContact());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateVendorContactView(2)));
        }

        [Fact]
        public void CanCreate_ValidContact()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateVendorContactView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateVendorContactView()));
        }

        [Fact]
        public void CanEdit_ValidContact()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateVendorContactView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
