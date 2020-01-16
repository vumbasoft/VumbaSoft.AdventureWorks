using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class BillOfMaterialValidatorTests : IDisposable
    {
        private BillOfMaterialValidator validator;
        private TestingContext context;
        private BillOfMaterial material;

        public BillOfMaterialValidatorTests()
        {
            context = new TestingContext();
            validator = new BillOfMaterialValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<BillOfMaterial>().Add(material = ObjectsFactory.CreateBillOfMaterial());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateBillOfMaterialView(2)));
        }

        [Fact]
        public void CanCreate_ValidMaterial()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateBillOfMaterialView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateBillOfMaterialView()));
        }

        [Fact]
        public void CanEdit_ValidMaterial()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateBillOfMaterialView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
