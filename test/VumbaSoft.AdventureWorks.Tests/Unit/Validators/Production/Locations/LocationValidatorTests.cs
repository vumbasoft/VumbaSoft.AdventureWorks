using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class LocationValidatorTests : IDisposable
    {
        private LocationValidator validator;
        private TestingContext context;
        private Location location;

        public LocationValidatorTests()
        {
            context = new TestingContext();
            validator = new LocationValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<Location>().Add(location = ObjectsFactory.CreateLocation());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateLocationView(2)));
        }

        [Fact]
        public void CanCreate_ValidLocation()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateLocationView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateLocationView()));
        }

        [Fact]
        public void CanEdit_ValidLocation()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateLocationView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
