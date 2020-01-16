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

namespace VumbaSoft.AdventureWorks.Controllers.Purchasing.Tests
{
    public class ShipMethodsControllerTests : ControllerTests
    {
        private ShipMethodsController controller;
        private IShipMethodValidator validator;
        private IShipMethodService service;
        private ShipMethodView method;

        public ShipMethodsControllerTests()
        {
            validator = Substitute.For<IShipMethodValidator>();
            service = Substitute.For<IShipMethodService>();

            method = ObjectsFactory.CreateShipMethodView();

            controller = Substitute.ForPartsOf<ShipMethodsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsMethodViews()
        {
            service.GetViews().Returns(Array.Empty<ShipMethodView>().AsQueryable());

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
            validator.CanCreate(method).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(method)).Model;
            Object expected = method;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Method()
        {
            validator.CanCreate(method).Returns(true);

            controller.Create(method);

            service.Received().Create(method);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(method).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(method);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<ShipMethodView>(method.Id).Returns(method);

            Object expected = NotEmptyView(controller, method);
            Object actual = controller.Details(method.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<ShipMethodView>(method.Id).Returns(method);

            Object expected = NotEmptyView(controller, method);
            Object actual = controller.Edit(method.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(method).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(method)).Model;
            Object expected = method;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Method()
        {
            validator.CanEdit(method).Returns(true);

            controller.Edit(method);

            service.Received().Edit(method);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(method).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(method);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<ShipMethodView>(method.Id).Returns(method);

            Object expected = NotEmptyView(controller, method);
            Object actual = controller.Delete(method.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesMethod()
        {
            controller.DeleteConfirmed(method.Id);

            service.Received().Delete(method.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(method.Id);

            Assert.Same(expected, actual);
        }
    }
}
