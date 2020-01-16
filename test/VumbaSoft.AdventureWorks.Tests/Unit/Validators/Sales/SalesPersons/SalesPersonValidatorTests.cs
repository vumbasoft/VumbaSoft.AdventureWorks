using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class SalesPersonValidatorTests : IDisposable
    {
        private SalesPersonValidator validator;
        private TestingContext context;
        private SalesPerson person;

        public SalesPersonValidatorTests()
        {
            context = new TestingContext();
            validator = new SalesPersonValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<SalesPerson>().Add(person = ObjectsFactory.CreateSalesPerson());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateSalesPersonView(2)));
        }

        [Fact]
        public void CanCreate_ValidPerson()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateSalesPersonView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateSalesPersonView()));
        }

        [Fact]
        public void CanEdit_ValidPerson()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateSalesPersonView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
