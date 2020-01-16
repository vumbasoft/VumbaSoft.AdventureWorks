using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ContactValidatorTests : IDisposable
    {
        private ContactValidator validator;
        private TestingContext context;
        private Contact contact;

        public ContactValidatorTests()
        {
            context = new TestingContext();
            validator = new ContactValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<Contact>().Add(contact = ObjectsFactory.CreateContact());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateContactView(2)));
        }

        [Fact]
        public void CanCreate_ValidContact()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateContactView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateContactView()));
        }

        [Fact]
        public void CanEdit_ValidContact()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateContactView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
