using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class DistrictValidatorTests : IDisposable
    {
        private DistrictValidator validator;
        private TestingContext context;
        private District district;

        public DistrictValidatorTests()
        {
            context = new TestingContext();
            validator = new DistrictValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<District>().Add(district = ObjectsFactory.CreateDistrict());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateDistrictView(2)));
        }

        [Fact]
        public void CanCreate_ValidDistrict()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateDistrictView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateDistrictView()));
        }

        [Fact]
        public void CanEdit_ValidDistrict()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateDistrictView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
