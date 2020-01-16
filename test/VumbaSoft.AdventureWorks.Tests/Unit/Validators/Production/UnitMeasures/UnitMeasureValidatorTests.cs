using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class UnitMeasureValidatorTests : IDisposable
    {
        private UnitMeasureValidator validator;
        private TestingContext context;
        private UnitMeasure measure;

        public UnitMeasureValidatorTests()
        {
            context = new TestingContext();
            validator = new UnitMeasureValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<UnitMeasure>().Add(measure = ObjectsFactory.CreateUnitMeasure());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateUnitMeasureView(2)));
        }

        [Fact]
        public void CanCreate_ValidMeasure()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateUnitMeasureView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateUnitMeasureView()));
        }

        [Fact]
        public void CanEdit_ValidMeasure()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateUnitMeasureView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
