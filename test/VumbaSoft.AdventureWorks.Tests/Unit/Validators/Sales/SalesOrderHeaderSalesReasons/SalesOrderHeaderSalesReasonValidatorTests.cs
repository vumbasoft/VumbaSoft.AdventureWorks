using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class SalesOrderHeaderSalesReasonValidatorTests : IDisposable
    {
        private SalesOrderHeaderSalesReasonValidator validator;
        private TestingContext context;
        private SalesOrderHeaderSalesReason reason;

        public SalesOrderHeaderSalesReasonValidatorTests()
        {
            context = new TestingContext();
            validator = new SalesOrderHeaderSalesReasonValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<SalesOrderHeaderSalesReason>().Add(reason = ObjectsFactory.CreateSalesOrderHeaderSalesReason());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateSalesOrderHeaderSalesReasonView(2)));
        }

        [Fact]
        public void CanCreate_ValidReason()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateSalesOrderHeaderSalesReasonView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateSalesOrderHeaderSalesReasonView()));
        }

        [Fact]
        public void CanEdit_ValidReason()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateSalesOrderHeaderSalesReasonView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
