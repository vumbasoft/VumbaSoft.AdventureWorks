using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class CustomCareTypeValidatorTests : IDisposable
    {
        private CustomCareTypeValidator validator;
        private TestingContext context;
        private CustomCareType type;

        public CustomCareTypeValidatorTests()
        {
            context = new TestingContext();
            validator = new CustomCareTypeValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<CustomCareType>().Add(type = ObjectsFactory.CreateCustomCareType());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateCustomCareTypeView(2)));
        }

        [Fact]
        public void CanCreate_ValidType()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateCustomCareTypeView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateCustomCareTypeView()));
        }

        [Fact]
        public void CanEdit_ValidType()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateCustomCareTypeView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
