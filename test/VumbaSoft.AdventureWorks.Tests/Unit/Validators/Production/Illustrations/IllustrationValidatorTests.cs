using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class IllustrationValidatorTests : IDisposable
    {
        private IllustrationValidator validator;
        private TestingContext context;
        private Illustration illustration;

        public IllustrationValidatorTests()
        {
            context = new TestingContext();
            validator = new IllustrationValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<Illustration>().Add(illustration = ObjectsFactory.CreateIllustration());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateIllustrationView(2)));
        }

        [Fact]
        public void CanCreate_ValidIllustration()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateIllustrationView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateIllustrationView()));
        }

        [Fact]
        public void CanEdit_ValidIllustration()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateIllustrationView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
