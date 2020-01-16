using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ProductReviewValidatorTests : IDisposable
    {
        private ProductReviewValidator validator;
        private TestingContext context;
        private ProductReview review;

        public ProductReviewValidatorTests()
        {
            context = new TestingContext();
            validator = new ProductReviewValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductReview>().Add(review = ObjectsFactory.CreateProductReview());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateProductReviewView(2)));
        }

        [Fact]
        public void CanCreate_ValidReview()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateProductReviewView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateProductReviewView()));
        }

        [Fact]
        public void CanEdit_ValidReview()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateProductReviewView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
