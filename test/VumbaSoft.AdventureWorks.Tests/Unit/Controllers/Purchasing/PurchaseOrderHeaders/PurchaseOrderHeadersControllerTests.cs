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
    public class PurchaseOrderHeadersControllerTests : ControllerTests
    {
        private PurchaseOrderHeadersController controller;
        private IPurchaseOrderHeaderValidator validator;
        private IPurchaseOrderHeaderService service;
        private PurchaseOrderHeaderView header;

        public PurchaseOrderHeadersControllerTests()
        {
            validator = Substitute.For<IPurchaseOrderHeaderValidator>();
            service = Substitute.For<IPurchaseOrderHeaderService>();

            header = ObjectsFactory.CreatePurchaseOrderHeaderView();

            controller = Substitute.ForPartsOf<PurchaseOrderHeadersController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsHeaderViews()
        {
            service.GetViews().Returns(Array.Empty<PurchaseOrderHeaderView>().AsQueryable());

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
            validator.CanCreate(header).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(header)).Model;
            Object expected = header;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Header()
        {
            validator.CanCreate(header).Returns(true);

            controller.Create(header);

            service.Received().Create(header);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(header).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(header);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<PurchaseOrderHeaderView>(header.Id).Returns(header);

            Object expected = NotEmptyView(controller, header);
            Object actual = controller.Details(header.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<PurchaseOrderHeaderView>(header.Id).Returns(header);

            Object expected = NotEmptyView(controller, header);
            Object actual = controller.Edit(header.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(header).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(header)).Model;
            Object expected = header;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Header()
        {
            validator.CanEdit(header).Returns(true);

            controller.Edit(header);

            service.Received().Edit(header);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(header).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(header);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<PurchaseOrderHeaderView>(header.Id).Returns(header);

            Object expected = NotEmptyView(controller, header);
            Object actual = controller.Delete(header.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesHeader()
        {
            controller.DeleteConfirmed(header.Id);

            service.Received().Delete(header.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(header.Id);

            Assert.Same(expected, actual);
        }
    }
}
