using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class AdventureworkFacilityValidatorTests : IDisposable
    {
        private AdventureworkFacilityValidator validator;
        private TestingContext context;
        private AdventureworkFacility facility;

        public AdventureworkFacilityValidatorTests()
        {
            context = new TestingContext();
            validator = new AdventureworkFacilityValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<AdventureworkFacility>().Add(facility = ObjectsFactory.CreateAdventureworkFacility());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateAdventureworkFacilityView(2)));
        }

        [Fact]
        public void CanCreate_ValidFacility()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateAdventureworkFacilityView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateAdventureworkFacilityView()));
        }

        [Fact]
        public void CanEdit_ValidFacility()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateAdventureworkFacilityView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
