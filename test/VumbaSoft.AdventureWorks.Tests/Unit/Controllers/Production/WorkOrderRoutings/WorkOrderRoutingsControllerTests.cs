using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using VumbaSoft.AdventureWorks.Controllers.Tests;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Tests;
using VumbaSoft.AdventureWorks.Validators;
using NSubstitute;
using System;
using System.Linq;
using Xunit;

namespace VumbaSoft.AdventureWorks.Controllers.Production.Tests
{
    public class WorkOrderRoutingsControllerTests : ControllerTests
    {
        private WorkOrderRoutingsController controller;
        private IWorkOrderRoutingValidator validator;
        private IWorkOrderRoutingService service;
        private WorkOrderRoutingView routing;

        public WorkOrderRoutingsControllerTests()
        {
            validator = Substitute.For<IWorkOrderRoutingValidator>();
            service = Substitute.For<IWorkOrderRoutingService>();

            routing = ObjectsFactory.CreateWorkOrderRoutingView();

            controller = Substitute.ForPartsOf<WorkOrderRoutingsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsRoutingViews()
        {
            service.GetViews().Returns(Array.Empty<WorkOrderRoutingView>().AsQueryable());

            Object actual = controller.Index().Model;
            Object expected = service.GetViews();

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_ReturnsEmptyView()
        {
            ViewResult actual = controller.Create();

            Assert.Null(actual.Model);
        }

        [Fact]
        public void Create_CanNotCreate_ReturnsSameView()
        {
            validator.CanCreate(routing).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(routing)).Model;
            Object expected = routing;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Routing()
        {
            validator.CanCreate(routing).Returns(true);

            controller.Create(routing);

            service.Received().Create(routing);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(routing).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(routing);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<WorkOrderRoutingView>(routing.Id).Returns(routing);

            Object expected = NotEmptyView(controller, routing);
            Object actual = controller.Details(routing.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<WorkOrderRoutingView>(routing.Id).Returns(routing);

            Object expected = NotEmptyView(controller, routing);
            Object actual = controller.Edit(routing.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(routing).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(routing)).Model;
            Object expected = routing;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Routing()
        {
            validator.CanEdit(routing).Returns(true);

            controller.Edit(routing);

            service.Received().Edit(routing);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(routing).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(routing);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<WorkOrderRoutingView>(routing.Id).Returns(routing);

            Object expected = NotEmptyView(controller, routing);
            Object actual = controller.Delete(routing.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesRouting()
        {
            controller.DeleteConfirmed(routing.Id);

            service.Received().Delete(routing.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(routing.Id);

            Assert.Same(expected, actual);
        }
    }
}
