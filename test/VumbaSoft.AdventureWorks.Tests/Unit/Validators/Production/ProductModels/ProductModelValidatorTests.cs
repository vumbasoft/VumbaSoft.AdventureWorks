using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ProductModelValidatorTests : IDisposable
    {
        private ProductModelValidator validator;
        private TestingContext context;
        private ProductModel model;

        public ProductModelValidatorTests()
        {
            context = new TestingContext();
            validator = new ProductModelValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductModel>().Add(model = ObjectsFactory.CreateProductModel());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateProductModelView(2)));
        }

        [Fact]
        public void CanCreate_ValidModel()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateProductModelView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateProductModelView()));
        }

        [Fact]
        public void CanEdit_ValidModel()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateProductModelView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
