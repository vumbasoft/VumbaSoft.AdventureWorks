using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class CountryValidatorTests : IDisposable
    {
        private CountryValidator validator;
        private TestingContext context;
        private Country country;

        public CountryValidatorTests()
        {
            context = new TestingContext();
            validator = new CountryValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<Country>().Add(country = ObjectsFactory.CreateCountry());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateCountryView(2)));
        }

        [Fact]
        public void CanCreate_ValidCountry()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateCountryView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateCountryView()));
        }

        [Fact]
        public void CanEdit_ValidCountry()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateCountryView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
