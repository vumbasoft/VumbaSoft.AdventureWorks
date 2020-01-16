using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class WorkOrderValidatorTests : IDisposable
    {
        private WorkOrderValidator validator;
        private TestingContext context;
        private WorkOrder order;

        public WorkOrderValidatorTests()
        {
            context = new TestingContext();
            validator = new WorkOrderValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<WorkOrder>().Add(order = ObjectsFactory.CreateWorkOrder());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateWorkOrderView(2)));
        }

        [Fact]
        public void CanCreate_ValidOrder()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateWorkOrderView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateWorkOrderView()));
        }

        [Fact]
        public void CanEdit_ValidOrder()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateWorkOrderView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
