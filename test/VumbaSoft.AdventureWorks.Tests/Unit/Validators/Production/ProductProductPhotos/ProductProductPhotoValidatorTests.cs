using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ProductProductPhotoValidatorTests : IDisposable
    {
        private ProductProductPhotoValidator validator;
        private TestingContext context;
        private ProductProductPhoto photo;

        public ProductProductPhotoValidatorTests()
        {
            context = new TestingContext();
            validator = new ProductProductPhotoValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductProductPhoto>().Add(photo = ObjectsFactory.CreateProductProductPhoto());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateProductProductPhotoView(2)));
        }

        [Fact]
        public void CanCreate_ValidPhoto()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateProductProductPhotoView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateProductProductPhotoView()));
        }

        [Fact]
        public void CanEdit_ValidPhoto()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateProductProductPhotoView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
