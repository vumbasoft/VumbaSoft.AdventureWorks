using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ProductModelProductDescriptionCultureValidatorTests : IDisposable
    {
        private ProductModelProductDescriptionCultureValidator validator;
        private TestingContext context;
        private ProductModelProductDescriptionCulture culture;

        public ProductModelProductDescriptionCultureValidatorTests()
        {
            context = new TestingContext();
            validator = new ProductModelProductDescriptionCultureValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductModelProductDescriptionCulture>().Add(culture = ObjectsFactory.CreateProductModelProductDescriptionCulture());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateProductModelProductDescriptionCultureView(2)));
        }

        [Fact]
        public void CanCreate_ValidCulture()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateProductModelProductDescriptionCultureView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateProductModelProductDescriptionCultureView()));
        }

        [Fact]
        public void CanEdit_ValidCulture()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateProductModelProductDescriptionCultureView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
