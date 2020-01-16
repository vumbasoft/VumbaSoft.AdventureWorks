using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class AddresstypeValidatorTests : IDisposable
    {
        private AddresstypeValidator validator;
        private TestingContext context;
        private Addresstype addresstype;

        public AddresstypeValidatorTests()
        {
            context = new TestingContext();
            validator = new AddresstypeValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<Addresstype>().Add(addresstype = ObjectsFactory.CreateAddresstype());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateAddresstypeView(2)));
        }

        [Fact]
        public void CanCreate_ValidAddresstype()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateAddresstypeView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateAddresstypeView()));
        }

        [Fact]
        public void CanEdit_ValidAddresstype()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateAddresstypeView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
