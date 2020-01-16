using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ProductPhotoValidatorTests : IDisposable
    {
        private ProductPhotoValidator validator;
        private TestingContext context;
        private ProductPhoto photo;

        public ProductPhotoValidatorTests()
        {
            context = new TestingContext();
            validator = new ProductPhotoValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductPhoto>().Add(photo = ObjectsFactory.CreateProductPhoto());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateProductPhotoView(2)));
        }

        [Fact]
        public void CanCreate_ValidPhoto()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateProductPhotoView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateProductPhotoView()));
        }

        [Fact]
        public void CanEdit_ValidPhoto()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateProductPhotoView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
