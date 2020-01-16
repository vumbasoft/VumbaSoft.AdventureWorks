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
    public class SalesOrderDetailsControllerTests : ControllerTests
    {
        private SalesOrderDetailsController controller;
        private ISalesOrderDetailValidator validator;
        private ISalesOrderDetailService service;
        private SalesOrderDetailView detail;

        public SalesOrderDetailsControllerTests()
        {
            validator = Substitute.For<ISalesOrderDetailValidator>();
            service = Substitute.For<ISalesOrderDetailService>();

            detail = ObjectsFactory.CreateSalesOrderDetailView();

            controller = Substitute.ForPartsOf<SalesOrderDetailsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsDetailViews()
        {
            service.GetViews().Returns(Array.Empty<SalesOrderDetailView>().AsQueryable());

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
            validator.CanCreate(detail).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(detail)).Model;
            Object expected = detail;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Detail()
        {
            validator.CanCreate(detail).Returns(true);

            controller.Create(detail);

            service.Received().Create(detail);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(detail).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(detail);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<SalesOrderDetailView>(detail.Id).Returns(detail);

            Object expected = NotEmptyView(controller, detail);
            Object actual = controller.Details(detail.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<SalesOrderDetailView>(detail.Id).Returns(detail);

            Object expected = NotEmptyView(controller, detail);
            Object actual = controller.Edit(detail.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(detail).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(detail)).Model;
            Object expected = detail;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Detail()
        {
            validator.CanEdit(detail).Returns(true);

            controller.Edit(detail);

            service.Received().Edit(detail);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(detail).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(detail);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<SalesOrderDetailView>(detail.Id).Returns(detail);

            Object expected = NotEmptyView(controller, detail);
            Object actual = controller.Delete(detail.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesDetail()
        {
            controller.DeleteConfirmed(detail.Id);

            service.Received().Delete(detail.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(detail.Id);

            Assert.Same(expected, actual);
        }
    }
}
