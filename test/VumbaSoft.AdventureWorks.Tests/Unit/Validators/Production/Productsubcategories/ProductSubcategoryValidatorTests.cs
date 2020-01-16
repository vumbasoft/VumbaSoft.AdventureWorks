using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ProductSubcategoryValidatorTests : IDisposable
    {
        private ProductSubcategoryValidator validator;
        private TestingContext context;
        private ProductSubcategory subcategory;

        public ProductSubcategoryValidatorTests()
        {
            context = new TestingContext();
            validator = new ProductSubcategoryValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductSubcategory>().Add(subcategory = ObjectsFactory.CreateProductSubcategory());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateProductSubcategoryView(2)));
        }

        [Fact]
        public void CanCreate_ValidSubcategory()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateProductSubcategoryView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateProductSubcategoryView()));
        }

        [Fact]
        public void CanEdit_ValidSubcategory()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateProductSubcategoryView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
