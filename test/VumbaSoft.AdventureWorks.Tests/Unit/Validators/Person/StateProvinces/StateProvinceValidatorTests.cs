using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class StateProvinceValidatorTests : IDisposable
    {
        private StateProvinceValidator validator;
        private TestingContext context;
        private StateProvince province;

        public StateProvinceValidatorTests()
        {
            context = new TestingContext();
            validator = new StateProvinceValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<StateProvince>().Add(province = ObjectsFactory.CreateStateProvince());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateStateProvinceView(2)));
        }

        [Fact]
        public void CanCreate_ValidProvince()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateStateProvinceView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateStateProvinceView()));
        }

        [Fact]
        public void CanEdit_ValidProvince()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateStateProvinceView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
