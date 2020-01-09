using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class LocalityValidatorTests : IDisposable
    {
        private LocalityValidator validator;
        private TestingContext context;
        private Locality locality;

        public LocalityValidatorTests()
        {
            context = new TestingContext();
            validator = new LocalityValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<Locality>().Add(locality = ObjectsFactory.CreateLocality());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateLocalityView(2)));
        }

        [Fact]
        public void CanCreate_ValidLocality()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateLocalityView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateLocalityView()));
        }

        [Fact]
        public void CanEdit_ValidLocality()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateLocalityView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
