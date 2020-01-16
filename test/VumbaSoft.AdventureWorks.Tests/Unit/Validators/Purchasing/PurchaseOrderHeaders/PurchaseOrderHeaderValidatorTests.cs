using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class PurchaseOrderHeaderValidatorTests : IDisposable
    {
        private PurchaseOrderHeaderValidator validator;
        private TestingContext context;
        private PurchaseOrderHeader header;

        public PurchaseOrderHeaderValidatorTests()
        {
            context = new TestingContext();
            validator = new PurchaseOrderHeaderValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<PurchaseOrderHeader>().Add(header = ObjectsFactory.CreatePurchaseOrderHeader());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreatePurchaseOrderHeaderView(2)));
        }

        [Fact]
        public void CanCreate_ValidHeader()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreatePurchaseOrderHeaderView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreatePurchaseOrderHeaderView()));
        }

        [Fact]
        public void CanEdit_ValidHeader()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreatePurchaseOrderHeaderView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
