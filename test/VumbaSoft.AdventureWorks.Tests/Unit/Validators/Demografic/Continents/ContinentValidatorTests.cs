using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ContinentValidatorTests : IDisposable
    {
        private ContinentValidator validator;
        private TestingContext context;
        private Continent continent;

        public ContinentValidatorTests()
        {
            context = new TestingContext();
            validator = new ContinentValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<Continent>().Add(continent = ObjectsFactory.CreateContinent());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateContinentView(2)));
        }

        [Fact]
        public void CanCreate_ValidContinent()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateContinentView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateContinentView()));
        }

        [Fact]
        public void CanEdit_ValidContinent()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateContinentView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
