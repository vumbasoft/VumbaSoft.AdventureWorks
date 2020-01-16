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

namespace VumbaSoft.AdventureWorks.Controllers.Sales.Tests
{
    public class SalesReasonsControllerTests : ControllerTests
    {
        private SalesReasonsController controller;
        private ISalesReasonValidator validator;
        private ISalesReasonService service;
        private SalesReasonView reason;

        public SalesReasonsControllerTests()
        {
            validator = Substitute.For<ISalesReasonValidator>();
            service = Substitute.For<ISalesReasonService>();

            reason = ObjectsFactory.CreateSalesReasonView();

            controller = Substitute.ForPartsOf<SalesReasonsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsReasonViews()
        {
            service.GetViews().Returns(Array.Empty<SalesReasonView>().AsQueryable());

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
            validator.CanCreate(reason).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(reason)).Model;
            Object expected = reason;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Reason()
        {
            validator.CanCreate(reason).Returns(true);

            controller.Create(reason);

            service.Received().Create(reason);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(reason).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(reason);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<SalesReasonView>(reason.Id).Returns(reason);

            Object expected = NotEmptyView(controller, reason);
            Object actual = controller.Details(reason.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<SalesReasonView>(reason.Id).Returns(reason);

            Object expected = NotEmptyView(controller, reason);
            Object actual = controller.Edit(reason.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(reason).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(reason)).Model;
            Object expected = reason;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Reason()
        {
            validator.CanEdit(reason).Returns(true);

            controller.Edit(reason);

            service.Received().Edit(reason);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(reason).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(reason);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<SalesReasonView>(reason.Id).Returns(reason);

            Object expected = NotEmptyView(controller, reason);
            Object actual = controller.Delete(reason.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesReason()
        {
            controller.DeleteConfirmed(reason.Id);

            service.Received().Delete(reason.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(reason.Id);

            Assert.Same(expected, actual);
        }
    }
}
