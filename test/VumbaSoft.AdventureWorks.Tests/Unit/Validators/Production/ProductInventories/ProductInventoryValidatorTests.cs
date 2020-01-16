using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ProductInventoryValidatorTests : IDisposable
    {
        private ProductInventoryValidator validator;
        private TestingContext context;
        private ProductInventory inventory;

        public ProductInventoryValidatorTests()
        {
            context = new TestingContext();
            validator = new ProductInventoryValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductInventory>().Add(inventory = ObjectsFactory.CreateProductInventory());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateProductInventoryView(2)));
        }

        [Fact]
        public void CanCreate_ValidInventory()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateProductInventoryView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateProductInventoryView()));
        }

        [Fact]
        public void CanEdit_ValidInventory()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateProductInventoryView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
