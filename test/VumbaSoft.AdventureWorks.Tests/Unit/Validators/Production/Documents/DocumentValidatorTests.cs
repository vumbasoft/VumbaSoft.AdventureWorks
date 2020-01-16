using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class DocumentValidatorTests : IDisposable
    {
        private DocumentValidator validator;
        private TestingContext context;
        private Document document;

        public DocumentValidatorTests()
        {
            context = new TestingContext();
            validator = new DocumentValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<Document>().Add(document = ObjectsFactory.CreateDocument());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateDocumentView(2)));
        }

        [Fact]
        public void CanCreate_ValidDocument()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateDocumentView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateDocumentView()));
        }

        [Fact]
        public void CanEdit_ValidDocument()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateDocumentView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
