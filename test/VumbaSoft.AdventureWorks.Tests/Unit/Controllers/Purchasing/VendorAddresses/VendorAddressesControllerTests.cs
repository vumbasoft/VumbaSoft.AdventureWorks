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
    public class VendorAddressesControllerTests : ControllerTests
    {
        private VendorAddressesController controller;
        private IVendorAddressValidator validator;
        private IVendorAddressService service;
        private VendorAddressView address;

        public VendorAddressesControllerTests()
        {
            validator = Substitute.For<IVendorAddressValidator>();
            service = Substitute.For<IVendorAddressService>();

            address = ObjectsFactory.CreateVendorAddressView();

            controller = Substitute.ForPartsOf<VendorAddressesController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsAddressViews()
        {
            service.GetViews().Returns(Array.Empty<VendorAddressView>().AsQueryable());

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
            validator.CanCreate(address).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(address)).Model;
            Object expected = address;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Address()
        {
            validator.CanCreate(address).Returns(true);

            controller.Create(address);

            service.Received().Create(address);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(address).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(address);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<VendorAddressView>(address.Id).Returns(address);

            Object expected = NotEmptyView(controller, address);
            Object actual = controller.Details(address.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<VendorAddressView>(address.Id).Returns(address);

            Object expected = NotEmptyView(controller, address);
            Object actual = controller.Edit(address.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(address).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(address)).Model;
            Object expected = address;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Address()
        {
            validator.CanEdit(address).Returns(true);

            controller.Edit(address);

            service.Received().Edit(address);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(address).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(address);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<VendorAddressView>(address.Id).Returns(address);

            Object expected = NotEmptyView(controller, address);
            Object actual = controller.Delete(address.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesAddress()
        {
            controller.DeleteConfirmed(address.Id);

            service.Received().Delete(address.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(address.Id);

            Assert.Same(expected, actual);
        }
    }
}
