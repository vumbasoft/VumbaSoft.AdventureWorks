using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ScrapReasonValidatorTests : IDisposable
    {
        private ScrapReasonValidator validator;
        private TestingContext context;
        private ScrapReason reason;

        public ScrapReasonValidatorTests()
        {
            context = new TestingContext();
            validator = new ScrapReasonValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<ScrapReason>().Add(reason = ObjectsFactory.CreateScrapReason());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateScrapReasonView(2)));
        }

        [Fact]
        public void CanCreate_ValidReason()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateScrapReasonView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateScrapReasonView()));
        }

        [Fact]
        public void CanEdit_ValidReason()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateScrapReasonView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
