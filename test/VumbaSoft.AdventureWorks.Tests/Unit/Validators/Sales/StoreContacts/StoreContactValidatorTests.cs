using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class StoreContactValidatorTests : IDisposable
    {
        private StoreContactValidator validator;
        private TestingContext context;
        private StoreContact contact;

        public StoreContactValidatorTests()
        {
            context = new TestingContext();
            validator = new StoreContactValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<StoreContact>().Add(contact = ObjectsFactory.CreateStoreContact());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateStoreContactView(2)));
        }

        [Fact]
        public void CanCreate_ValidContact()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateStoreContactView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateStoreContactView()));
        }

        [Fact]
        public void CanEdit_ValidContact()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateStoreContactView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
