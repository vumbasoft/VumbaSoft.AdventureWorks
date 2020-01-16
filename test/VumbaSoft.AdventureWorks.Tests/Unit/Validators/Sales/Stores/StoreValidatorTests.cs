using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class StoreValidatorTests : IDisposable
    {
        private StoreValidator validator;
        private TestingContext context;
        private Store store;

        public StoreValidatorTests()
        {
            context = new TestingContext();
            validator = new StoreValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<Store>().Add(store = ObjectsFactory.CreateStore());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateStoreView(2)));
        }

        [Fact]
        public void CanCreate_ValidStore()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateStoreView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateStoreView()));
        }

        [Fact]
        public void CanEdit_ValidStore()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateStoreView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
