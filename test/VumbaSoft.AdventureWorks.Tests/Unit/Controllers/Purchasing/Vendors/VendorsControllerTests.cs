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
    public class VendorsControllerTests : ControllerTests
    {
        private VendorsController controller;
        private IVendorValidator validator;
        private IVendorService service;
        private VendorView vendor;

        public VendorsControllerTests()
        {
            validator = Substitute.For<IVendorValidator>();
            service = Substitute.For<IVendorService>();

            vendor = ObjectsFactory.CreateVendorView();

            controller = Substitute.ForPartsOf<VendorsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsVendorViews()
        {
            service.GetViews().Returns(Array.Empty<VendorView>().AsQueryable());

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
            validator.CanCreate(vendor).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(vendor)).Model;
            Object expected = vendor;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Vendor()
        {
            validator.CanCreate(vendor).Returns(true);

            controller.Create(vendor);

            service.Received().Create(vendor);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(vendor).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(vendor);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<VendorView>(vendor.Id).Returns(vendor);

            Object expected = NotEmptyView(controller, vendor);
            Object actual = controller.Details(vendor.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<VendorView>(vendor.Id).Returns(vendor);

            Object expected = NotEmptyView(controller, vendor);
            Object actual = controller.Edit(vendor.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(vendor).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(vendor)).Model;
            Object expected = vendor;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Vendor()
        {
            validator.CanEdit(vendor).Returns(true);

            controller.Edit(vendor);

            service.Received().Edit(vendor);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(vendor).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(vendor);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<VendorView>(vendor.Id).Returns(vendor);

            Object expected = NotEmptyView(controller, vendor);
            Object actual = controller.Delete(vendor.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesVendor()
        {
            controller.DeleteConfirmed(vendor.Id);

            service.Received().Delete(vendor.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(vendor.Id);

            Assert.Same(expected, actual);
        }
    }
}
