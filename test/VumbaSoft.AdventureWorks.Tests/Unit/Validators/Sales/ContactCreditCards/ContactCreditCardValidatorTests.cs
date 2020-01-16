using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ContactCreditCardValidatorTests : IDisposable
    {
        private ContactCreditCardValidator validator;
        private TestingContext context;
        private ContactCreditCard card;

        public ContactCreditCardValidatorTests()
        {
            context = new TestingContext();
            validator = new ContactCreditCardValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<ContactCreditCard>().Add(card = ObjectsFactory.CreateContactCreditCard());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateContactCreditCardView(2)));
        }

        [Fact]
        public void CanCreate_ValidCard()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateContactCreditCardView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateContactCreditCardView()));
        }

        [Fact]
        public void CanEdit_ValidCard()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateContactCreditCardView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
