using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class SalesOrderDetailValidatorTests : IDisposable
    {
        private SalesOrderDetailValidator validator;
        private TestingContext context;
        private SalesOrderDetail detail;

        public SalesOrderDetailValidatorTests()
        {
            context = new TestingContext();
            validator = new SalesOrderDetailValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<SalesOrderDetail>().Add(detail = ObjectsFactory.CreateSalesOrderDetail());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateSalesOrderDetailView(2)));
        }

        [Fact]
        public void CanCreate_ValidDetail()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateSalesOrderDetailView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateSalesOrderDetailView()));
        }

        [Fact]
        public void CanEdit_ValidDetail()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateSalesOrderDetailView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
