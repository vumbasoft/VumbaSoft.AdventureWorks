using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class CurrencyRateValidatorTests : IDisposable
    {
        private CurrencyRateValidator validator;
        private TestingContext context;
        private CurrencyRate rate;

        public CurrencyRateValidatorTests()
        {
            context = new TestingContext();
            validator = new CurrencyRateValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<CurrencyRate>().Add(rate = ObjectsFactory.CreateCurrencyRate());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateCurrencyRateView(2)));
        }

        [Fact]
        public void CanCreate_ValidRate()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateCurrencyRateView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateCurrencyRateView()));
        }

        [Fact]
        public void CanEdit_ValidRate()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateCurrencyRateView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
