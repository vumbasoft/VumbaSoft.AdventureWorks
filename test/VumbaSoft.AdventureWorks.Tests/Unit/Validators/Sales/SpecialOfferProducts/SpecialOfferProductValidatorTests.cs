using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class SpecialOfferProductValidatorTests : IDisposable
    {
        private SpecialOfferProductValidator validator;
        private TestingContext context;
        private SpecialOfferProduct product;

        public SpecialOfferProductValidatorTests()
        {
            context = new TestingContext();
            validator = new SpecialOfferProductValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<SpecialOfferProduct>().Add(product = ObjectsFactory.CreateSpecialOfferProduct());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateSpecialOfferProductView(2)));
        }

        [Fact]
        public void CanCreate_ValidProduct()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateSpecialOfferProductView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateSpecialOfferProductView()));
        }

        [Fact]
        public void CanEdit_ValidProduct()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateSpecialOfferProductView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
