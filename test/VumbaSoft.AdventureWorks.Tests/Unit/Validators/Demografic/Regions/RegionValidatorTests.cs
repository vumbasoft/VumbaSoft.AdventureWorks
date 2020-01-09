using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class RegionValidatorTests : IDisposable
    {
        private RegionValidator validator;
        private TestingContext context;
        private Region region;

        public RegionValidatorTests()
        {
            context = new TestingContext();
            validator = new RegionValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<Region>().Add(region = ObjectsFactory.CreateRegion());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateRegionView(2)));
        }

        [Fact]
        public void CanCreate_ValidRegion()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateRegionView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateRegionView()));
        }

        [Fact]
        public void CanEdit_ValidRegion()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateRegionView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
