using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class WorkOrderRoutingValidatorTests : IDisposable
    {
        private WorkOrderRoutingValidator validator;
        private TestingContext context;
        private WorkOrderRouting routing;

        public WorkOrderRoutingValidatorTests()
        {
            context = new TestingContext();
            validator = new WorkOrderRoutingValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<WorkOrderRouting>().Add(routing = ObjectsFactory.CreateWorkOrderRouting());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateWorkOrderRoutingView(2)));
        }

        [Fact]
        public void CanCreate_ValidRouting()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateWorkOrderRoutingView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateWorkOrderRoutingView()));
        }

        [Fact]
        public void CanEdit_ValidRouting()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateWorkOrderRoutingView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
