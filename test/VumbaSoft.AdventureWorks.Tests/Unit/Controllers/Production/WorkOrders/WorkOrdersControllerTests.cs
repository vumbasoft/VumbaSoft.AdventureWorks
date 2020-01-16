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
    public class WorkOrdersControllerTests : ControllerTests
    {
        private WorkOrdersController controller;
        private IWorkOrderValidator validator;
        private IWorkOrderService service;
        private WorkOrderView order;

        public WorkOrdersControllerTests()
        {
            validator = Substitute.For<IWorkOrderValidator>();
            service = Substitute.For<IWorkOrderService>();

            order = ObjectsFactory.CreateWorkOrderView();

            controller = Substitute.ForPartsOf<WorkOrdersController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsOrderViews()
        {
            service.GetViews().Returns(Array.Empty<WorkOrderView>().AsQueryable());

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
            validator.CanCreate(order).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(order)).Model;
            Object expected = order;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Order()
        {
            validator.CanCreate(order).Returns(true);

            controller.Create(order);

            service.Received().Create(order);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(order).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(order);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<WorkOrderView>(order.Id).Returns(order);

            Object expected = NotEmptyView(controller, order);
            Object actual = controller.Details(order.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<WorkOrderView>(order.Id).Returns(order);

            Object expected = NotEmptyView(controller, order);
            Object actual = controller.Edit(order.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(order).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(order)).Model;
            Object expected = order;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Order()
        {
            validator.CanEdit(order).Returns(true);

            controller.Edit(order);

            service.Received().Edit(order);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(order).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(order);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<WorkOrderView>(order.Id).Returns(order);

            Object expected = NotEmptyView(controller, order);
            Object actual = controller.Delete(order.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesOrder()
        {
            controller.DeleteConfirmed(order.Id);

            service.Received().Delete(order.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(order.Id);

            Assert.Same(expected, actual);
        }
    }
}
