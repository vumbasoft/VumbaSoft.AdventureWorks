using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class TenantValidatorTests : IDisposable
    {
        private TenantValidator validator;
        private TestingContext context;
        private Tenant tenant;

        public TenantValidatorTests()
        {
            context = new TestingContext();
            validator = new TenantValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<Tenant>().Add(tenant = ObjectsFactory.CreateTenant());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateTenantView(2)));
        }

        [Fact]
        public void CanCreate_ValidTenant()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateTenantView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateTenantView()));
        }

        [Fact]
        public void CanEdit_ValidTenant()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateTenantView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
