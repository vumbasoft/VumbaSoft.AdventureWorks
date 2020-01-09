using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class CityValidatorTests : IDisposable
    {
        private CityValidator validator;
        private TestingContext context;
        private City city;

        public CityValidatorTests()
        {
            context = new TestingContext();
            validator = new CityValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<City>().Add(city = ObjectsFactory.CreateCity());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateCityView(2)));
        }

        [Fact]
        public void CanCreate_ValidCity()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateCityView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateCityView()));
        }

        [Fact]
        public void CanEdit_ValidCity()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateCityView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
