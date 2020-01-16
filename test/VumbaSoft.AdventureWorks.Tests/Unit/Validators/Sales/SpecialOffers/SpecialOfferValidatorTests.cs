using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class SpecialOfferValidatorTests : IDisposable
    {
        private SpecialOfferValidator validator;
        private TestingContext context;
        private SpecialOffer offer;

        public SpecialOfferValidatorTests()
        {
            context = new TestingContext();
            validator = new SpecialOfferValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<SpecialOffer>().Add(offer = ObjectsFactory.CreateSpecialOffer());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateSpecialOfferView(2)));
        }

        [Fact]
        public void CanCreate_ValidOffer()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateSpecialOfferView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateSpecialOfferView()));
        }

        [Fact]
        public void CanEdit_ValidOffer()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateSpecialOfferView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
