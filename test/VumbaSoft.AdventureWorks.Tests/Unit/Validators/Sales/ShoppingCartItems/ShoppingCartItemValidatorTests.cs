using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ShoppingCartItemValidatorTests : IDisposable
    {
        private ShoppingCartItemValidator validator;
        private TestingContext context;
        private ShoppingCartItem item;

        public ShoppingCartItemValidatorTests()
        {
            context = new TestingContext();
            validator = new ShoppingCartItemValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<ShoppingCartItem>().Add(item = ObjectsFactory.CreateShoppingCartItem());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateShoppingCartItemView(2)));
        }

        [Fact]
        public void CanCreate_ValidItem()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateShoppingCartItemView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateShoppingCartItemView()));
        }

        [Fact]
        public void CanEdit_ValidItem()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateShoppingCartItemView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
