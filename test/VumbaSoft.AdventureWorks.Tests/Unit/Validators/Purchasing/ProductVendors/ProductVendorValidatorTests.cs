using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ProductVendorValidatorTests : IDisposable
    {
        private ProductVendorValidator validator;
        private TestingContext context;
        private ProductVendor vendor;

        public ProductVendorValidatorTests()
        {
            context = new TestingContext();
            validator = new ProductVendorValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductVendor>().Add(vendor = ObjectsFactory.CreateProductVendor());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateProductVendorView(2)));
        }

        [Fact]
        public void CanCreate_ValidVendor()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateProductVendorView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateProductVendorView()));
        }

        [Fact]
        public void CanEdit_ValidVendor()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateProductVendorView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
