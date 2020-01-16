using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class SalesOrderHeaderValidatorTests : IDisposable
    {
        private SalesOrderHeaderValidator validator;
        private TestingContext context;
        private SalesOrderHeader header;

        public SalesOrderHeaderValidatorTests()
        {
            context = new TestingContext();
            validator = new SalesOrderHeaderValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<SalesOrderHeader>().Add(header = ObjectsFactory.CreateSalesOrderHeader());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateSalesOrderHeaderView(2)));
        }

        [Fact]
        public void CanCreate_ValidHeader()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateSalesOrderHeaderView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateSalesOrderHeaderView()));
        }

        [Fact]
        public void CanEdit_ValidHeader()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateSalesOrderHeaderView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
