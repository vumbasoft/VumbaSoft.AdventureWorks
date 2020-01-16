using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ProductModelIllustrationValidatorTests : IDisposable
    {
        private ProductModelIllustrationValidator validator;
        private TestingContext context;
        private ProductModelIllustration illustration;

        public ProductModelIllustrationValidatorTests()
        {
            context = new TestingContext();
            validator = new ProductModelIllustrationValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductModelIllustration>().Add(illustration = ObjectsFactory.CreateProductModelIllustration());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateProductModelIllustrationView(2)));
        }

        [Fact]
        public void CanCreate_ValidIllustration()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateProductModelIllustrationView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateProductModelIllustrationView()));
        }

        [Fact]
        public void CanEdit_ValidIllustration()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateProductModelIllustrationView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
