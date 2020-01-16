using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class PurchaseOrderDetailValidatorTests : IDisposable
    {
        private PurchaseOrderDetailValidator validator;
        private TestingContext context;
        private PurchaseOrderDetail detail;

        public PurchaseOrderDetailValidatorTests()
        {
            context = new TestingContext();
            validator = new PurchaseOrderDetailValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<PurchaseOrderDetail>().Add(detail = ObjectsFactory.CreatePurchaseOrderDetail());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreatePurchaseOrderDetailView(2)));
        }

        [Fact]
        public void CanCreate_ValidDetail()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreatePurchaseOrderDetailView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreatePurchaseOrderDetailView()));
        }

        [Fact]
        public void CanEdit_ValidDetail()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreatePurchaseOrderDetailView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
