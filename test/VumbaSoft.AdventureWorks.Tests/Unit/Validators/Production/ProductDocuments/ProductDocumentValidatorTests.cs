using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ProductDocumentValidatorTests : IDisposable
    {
        private ProductDocumentValidator validator;
        private TestingContext context;
        private ProductDocument document;

        public ProductDocumentValidatorTests()
        {
            context = new TestingContext();
            validator = new ProductDocumentValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductDocument>().Add(document = ObjectsFactory.CreateProductDocument());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateProductDocumentView(2)));
        }

        [Fact]
        public void CanCreate_ValidDocument()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateProductDocumentView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateProductDocumentView()));
        }

        [Fact]
        public void CanEdit_ValidDocument()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateProductDocumentView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
