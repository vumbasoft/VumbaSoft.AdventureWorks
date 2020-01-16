using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ShipMethodValidatorTests : IDisposable
    {
        private ShipMethodValidator validator;
        private TestingContext context;
        private ShipMethod method;

        public ShipMethodValidatorTests()
        {
            context = new TestingContext();
            validator = new ShipMethodValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<ShipMethod>().Add(method = ObjectsFactory.CreateShipMethod());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateShipMethodView(2)));
        }

        [Fact]
        public void CanCreate_ValidMethod()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateShipMethodView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateShipMethodView()));
        }

        [Fact]
        public void CanEdit_ValidMethod()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateShipMethodView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
