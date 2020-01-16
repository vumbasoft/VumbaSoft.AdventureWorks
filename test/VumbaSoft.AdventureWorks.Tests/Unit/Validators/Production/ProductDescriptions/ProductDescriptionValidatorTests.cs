using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ProductDescriptionValidatorTests : IDisposable
    {
        private ProductDescriptionValidator validator;
        private TestingContext context;
        private ProductDescription description;

        public ProductDescriptionValidatorTests()
        {
            context = new TestingContext();
            validator = new ProductDescriptionValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductDescription>().Add(description = ObjectsFactory.CreateProductDescription());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateProductDescriptionView(2)));
        }

        [Fact]
        public void CanCreate_ValidDescription()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateProductDescriptionView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateProductDescriptionView()));
        }

        [Fact]
        public void CanEdit_ValidDescription()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateProductDescriptionView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
