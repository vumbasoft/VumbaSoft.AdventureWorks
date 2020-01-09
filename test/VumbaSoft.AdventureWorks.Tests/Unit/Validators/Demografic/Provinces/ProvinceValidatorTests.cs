using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class ProvinceValidatorTests : IDisposable
    {
        private ProvinceValidator validator;
        private TestingContext context;
        private Province province;

        public ProvinceValidatorTests()
        {
            context = new TestingContext();
            validator = new ProvinceValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<Province>().Add(province = ObjectsFactory.CreateProvince());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateProvinceView(2)));
        }

        [Fact]
        public void CanCreate_ValidProvince()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateProvinceView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateProvinceView()));
        }

        [Fact]
        public void CanEdit_ValidProvince()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateProvinceView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
