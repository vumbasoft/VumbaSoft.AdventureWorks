using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ProductListPriceHistoryValidatorTests : IDisposable
    {
        private ProductListPriceHistoryValidator validator;
        private TestingContext context;
        private ProductListPriceHistory history;

        public ProductListPriceHistoryValidatorTests()
        {
            context = new TestingContext();
            validator = new ProductListPriceHistoryValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductListPriceHistory>().Add(history = ObjectsFactory.CreateProductListPriceHistory());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateProductListPriceHistoryView(2)));
        }

        [Fact]
        public void CanCreate_ValidHistory()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateProductListPriceHistoryView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateProductListPriceHistoryView()));
        }

        [Fact]
        public void CanEdit_ValidHistory()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateProductListPriceHistoryView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
