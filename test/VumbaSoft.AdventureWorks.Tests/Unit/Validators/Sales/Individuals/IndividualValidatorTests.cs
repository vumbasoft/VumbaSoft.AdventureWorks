using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class IndividualValidatorTests : IDisposable
    {
        private IndividualValidator validator;
        private TestingContext context;
        private Individual individual;

        public IndividualValidatorTests()
        {
            context = new TestingContext();
            validator = new IndividualValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<Individual>().Add(individual = ObjectsFactory.CreateIndividual());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateIndividualView(2)));
        }

        [Fact]
        public void CanCreate_ValidIndividual()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateIndividualView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateIndividualView()));
        }

        [Fact]
        public void CanEdit_ValidIndividual()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateIndividualView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
