using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class CountryRegionCurrencyValidatorTests : IDisposable
    {
        private CountryRegionCurrencyValidator validator;
        private TestingContext context;
        private CountryRegionCurrency currency;

        public CountryRegionCurrencyValidatorTests()
        {
            context = new TestingContext();
            validator = new CountryRegionCurrencyValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<CountryRegionCurrency>().Add(currency = ObjectsFactory.CreateCountryRegionCurrency());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateCountryRegionCurrencyView(2)));
        }

        [Fact]
        public void CanCreate_ValidCurrency()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateCountryRegionCurrencyView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateCountryRegionCurrencyView()));
        }

        [Fact]
        public void CanEdit_ValidCurrency()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateCountryRegionCurrencyView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
