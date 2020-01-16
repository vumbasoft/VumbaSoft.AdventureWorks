using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class SalesPersonQuotaHistoryValidatorTests : IDisposable
    {
        private SalesPersonQuotaHistoryValidator validator;
        private TestingContext context;
        private SalesPersonQuotaHistory history;

        public SalesPersonQuotaHistoryValidatorTests()
        {
            context = new TestingContext();
            validator = new SalesPersonQuotaHistoryValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<SalesPersonQuotaHistory>().Add(history = ObjectsFactory.CreateSalesPersonQuotaHistory());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateSalesPersonQuotaHistoryView(2)));
        }

        [Fact]
        public void CanCreate_ValidHistory()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateSalesPersonQuotaHistoryView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateSalesPersonQuotaHistoryView()));
        }

        [Fact]
        public void CanEdit_ValidHistory()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateSalesPersonQuotaHistoryView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
