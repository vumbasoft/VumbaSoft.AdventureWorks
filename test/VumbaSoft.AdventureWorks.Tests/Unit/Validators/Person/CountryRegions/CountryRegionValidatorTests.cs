using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class CountryRegionValidatorTests : IDisposable
    {
        private CountryRegionValidator validator;
        private TestingContext context;
        private CountryRegion region;

        public CountryRegionValidatorTests()
        {
            context = new TestingContext();
            validator = new CountryRegionValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<CountryRegion>().Add(region = ObjectsFactory.CreateCountryRegion());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateCountryRegionView(2)));
        }

        [Fact]
        public void CanCreate_ValidRegion()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateCountryRegionView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateCountryRegionView()));
        }

        [Fact]
        public void CanEdit_ValidRegion()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateCountryRegionView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
