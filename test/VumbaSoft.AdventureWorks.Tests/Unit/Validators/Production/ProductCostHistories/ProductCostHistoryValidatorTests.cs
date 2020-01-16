using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ProductCostHistoryValidatorTests : IDisposable
    {
        private ProductCostHistoryValidator validator;
        private TestingContext context;
        private ProductCostHistory history;

        public ProductCostHistoryValidatorTests()
        {
            context = new TestingContext();
            validator = new ProductCostHistoryValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductCostHistory>().Add(history = ObjectsFactory.CreateProductCostHistory());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateProductCostHistoryView(2)));
        }

        [Fact]
        public void CanCreate_ValidHistory()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateProductCostHistoryView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateProductCostHistoryView()));
        }

        [Fact]
        public void CanEdit_ValidHistory()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateProductCostHistoryView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
