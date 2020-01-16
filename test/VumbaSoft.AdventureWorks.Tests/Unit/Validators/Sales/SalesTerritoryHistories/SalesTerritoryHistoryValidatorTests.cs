using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class SalesTerritoryHistoryValidatorTests : IDisposable
    {
        private SalesTerritoryHistoryValidator validator;
        private TestingContext context;
        private SalesTerritoryHistory history;

        public SalesTerritoryHistoryValidatorTests()
        {
            context = new TestingContext();
            validator = new SalesTerritoryHistoryValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<SalesTerritoryHistory>().Add(history = ObjectsFactory.CreateSalesTerritoryHistory());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateSalesTerritoryHistoryView(2)));
        }

        [Fact]
        public void CanCreate_ValidHistory()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateSalesTerritoryHistoryView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateSalesTerritoryHistoryView()));
        }

        [Fact]
        public void CanEdit_ValidHistory()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateSalesTerritoryHistoryView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
