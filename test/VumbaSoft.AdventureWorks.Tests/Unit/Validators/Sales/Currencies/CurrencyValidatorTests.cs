using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class CurrencyValidatorTests : IDisposable
    {
        private CurrencyValidator validator;
        private TestingContext context;
        private Currency currency;

        public CurrencyValidatorTests()
        {
            context = new TestingContext();
            validator = new CurrencyValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<Currency>().Add(currency = ObjectsFactory.CreateCurrency());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateCurrencyView(2)));
        }

        [Fact]
        public void CanCreate_ValidCurrency()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateCurrencyView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateCurrencyView()));
        }

        [Fact]
        public void CanEdit_ValidCurrency()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateCurrencyView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
