using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class SalesTerritoryValidatorTests : IDisposable
    {
        private SalesTerritoryValidator validator;
        private TestingContext context;
        private SalesTerritory territory;

        public SalesTerritoryValidatorTests()
        {
            context = new TestingContext();
            validator = new SalesTerritoryValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<SalesTerritory>().Add(territory = ObjectsFactory.CreateSalesTerritory());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateSalesTerritoryView(2)));
        }

        [Fact]
        public void CanCreate_ValidTerritory()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateSalesTerritoryView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateSalesTerritoryView()));
        }

        [Fact]
        public void CanEdit_ValidTerritory()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateSalesTerritoryView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
