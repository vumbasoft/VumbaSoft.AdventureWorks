using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class SalesReasonValidatorTests : IDisposable
    {
        private SalesReasonValidator validator;
        private TestingContext context;
        private SalesReason reason;

        public SalesReasonValidatorTests()
        {
            context = new TestingContext();
            validator = new SalesReasonValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<SalesReason>().Add(reason = ObjectsFactory.CreateSalesReason());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateSalesReasonView(2)));
        }

        [Fact]
        public void CanCreate_ValidReason()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateSalesReasonView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateSalesReasonView()));
        }

        [Fact]
        public void CanEdit_ValidReason()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateSalesReasonView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
