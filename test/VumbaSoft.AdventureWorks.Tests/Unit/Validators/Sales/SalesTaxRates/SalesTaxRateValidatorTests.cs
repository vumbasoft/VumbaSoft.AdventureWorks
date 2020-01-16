using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class SalesTaxRateValidatorTests : IDisposable
    {
        private SalesTaxRateValidator validator;
        private TestingContext context;
        private SalesTaxRate rate;

        public SalesTaxRateValidatorTests()
        {
            context = new TestingContext();
            validator = new SalesTaxRateValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<SalesTaxRate>().Add(rate = ObjectsFactory.CreateSalesTaxRate());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateSalesTaxRateView(2)));
        }

        [Fact]
        public void CanCreate_ValidRate()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateSalesTaxRateView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateSalesTaxRateView()));
        }

        [Fact]
        public void CanEdit_ValidRate()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateSalesTaxRateView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
