using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class VendorValidatorTests : IDisposable
    {
        private VendorValidator validator;
        private TestingContext context;
        private Vendor vendor;

        public VendorValidatorTests()
        {
            context = new TestingContext();
            validator = new VendorValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<Vendor>().Add(vendor = ObjectsFactory.CreateVendor());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateVendorView(2)));
        }

        [Fact]
        public void CanCreate_ValidVendor()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateVendorView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateVendorView()));
        }

        [Fact]
        public void CanEdit_ValidVendor()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateVendorView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
