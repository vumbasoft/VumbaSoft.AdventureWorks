using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ProductValidatorTests : IDisposable
    {
        private ProductValidator validator;
        private TestingContext context;
        private Product product;

        public ProductValidatorTests()
        {
            context = new TestingContext();
            validator = new ProductValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<Product>().Add(product = ObjectsFactory.CreateProduct());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateProductView(2)));
        }

        [Fact]
        public void CanCreate_ValidProduct()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateProductView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateProductView()));
        }

        [Fact]
        public void CanEdit_ValidProduct()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateProductView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
