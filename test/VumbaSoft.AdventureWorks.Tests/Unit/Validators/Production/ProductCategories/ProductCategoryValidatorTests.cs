using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ProductCategoryValidatorTests : IDisposable
    {
        private ProductCategoryValidator validator;
        private TestingContext context;
        private ProductCategory category;

        public ProductCategoryValidatorTests()
        {
            context = new TestingContext();
            validator = new ProductCategoryValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductCategory>().Add(category = ObjectsFactory.CreateProductCategory());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateProductCategoryView(2)));
        }

        [Fact]
        public void CanCreate_ValidCategory()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateProductCategoryView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateProductCategoryView()));
        }

        [Fact]
        public void CanEdit_ValidCategory()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateProductCategoryView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
