using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ContactTypeValidatorTests : IDisposable
    {
        private ContactTypeValidator validator;
        private TestingContext context;
        private ContactType type;

        public ContactTypeValidatorTests()
        {
            context = new TestingContext();
            validator = new ContactTypeValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<ContactType>().Add(type = ObjectsFactory.CreateContactType());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateContactTypeView(2)));
        }

        [Fact]
        public void CanCreate_ValidType()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateContactTypeView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateContactTypeView()));
        }

        [Fact]
        public void CanEdit_ValidType()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateContactTypeView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
