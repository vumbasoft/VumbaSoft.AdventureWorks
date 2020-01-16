using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class CultureValidatorTests : IDisposable
    {
        private CultureValidator validator;
        private TestingContext context;
        private Culture culture;

        public CultureValidatorTests()
        {
            context = new TestingContext();
            validator = new CultureValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<Culture>().Add(culture = ObjectsFactory.CreateCulture());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateCultureView(2)));
        }

        [Fact]
        public void CanCreate_ValidCulture()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateCultureView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateCultureView()));
        }

        [Fact]
        public void CanEdit_ValidCulture()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateCultureView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
