using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ShiftValidatorTests : IDisposable
    {
        private ShiftValidator validator;
        private TestingContext context;
        private Shift shift;

        public ShiftValidatorTests()
        {
            context = new TestingContext();
            validator = new ShiftValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<Shift>().Add(shift = ObjectsFactory.CreateShift());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateShiftView(2)));
        }

        [Fact]
        public void CanCreate_ValidShift()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateShiftView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateShiftView()));
        }

        [Fact]
        public void CanEdit_ValidShift()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateShiftView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
