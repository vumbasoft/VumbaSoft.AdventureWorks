using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class CreditCardValidatorTests : IDisposable
    {
        private CreditCardValidator validator;
        private TestingContext context;
        private CreditCard card;

        public CreditCardValidatorTests()
        {
            context = new TestingContext();
            validator = new CreditCardValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<CreditCard>().Add(card = ObjectsFactory.CreateCreditCard());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateCreditCardView(2)));
        }

        [Fact]
        public void CanCreate_ValidCard()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateCreditCardView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateCreditCardView()));
        }

        [Fact]
        public void CanEdit_ValidCard()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateCreditCardView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
