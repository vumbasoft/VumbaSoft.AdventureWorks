using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ContinentRegionValidatorTests : IDisposable
    {
        private ContinentRegionValidator validator;
        private TestingContext context;
        private ContinentRegion region;

        public ContinentRegionValidatorTests()
        {
            context = new TestingContext();
            validator = new ContinentRegionValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<ContinentRegion>().Add(region = ObjectsFactory.CreateContinentRegion());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateContinentRegionView(2)));
        }

        [Fact]
        public void CanCreate_ValidRegion()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateContinentRegionView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateContinentRegionView()));
        }

        [Fact]
        public void CanEdit_ValidRegion()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateContinentRegionView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
