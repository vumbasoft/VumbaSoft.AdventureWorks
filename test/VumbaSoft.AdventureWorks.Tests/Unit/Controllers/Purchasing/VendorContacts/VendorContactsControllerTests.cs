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
    public class VendorContactsControllerTests : ControllerTests
    {
        private VendorContactsController controller;
        private IVendorContactValidator validator;
        private IVendorContactService service;
        private VendorContactView contact;

        public VendorContactsControllerTests()
        {
            validator = Substitute.For<IVendorContactValidator>();
            service = Substitute.For<IVendorContactService>();

            contact = ObjectsFactory.CreateVendorContactView();

            controller = Substitute.ForPartsOf<VendorContactsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsContactViews()
        {
            service.GetViews().Returns(Array.Empty<VendorContactView>().AsQueryable());

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
            validator.CanCreate(contact).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(contact)).Model;
            Object expected = contact;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Contact()
        {
            validator.CanCreate(contact).Returns(true);

            controller.Create(contact);

            service.Received().Create(contact);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(contact).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(contact);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<VendorContactView>(contact.Id).Returns(contact);

            Object expected = NotEmptyView(controller, contact);
            Object actual = controller.Details(contact.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<VendorContactView>(contact.Id).Returns(contact);

            Object expected = NotEmptyView(controller, contact);
            Object actual = controller.Edit(contact.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(contact).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(contact)).Model;
            Object expected = contact;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Contact()
        {
            validator.CanEdit(contact).Returns(true);

            controller.Edit(contact);

            service.Received().Edit(contact);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(contact).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(contact);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<VendorContactView>(contact.Id).Returns(contact);

            Object expected = NotEmptyView(controller, contact);
            Object actual = controller.Delete(contact.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesContact()
        {
            controller.DeleteConfirmed(contact.Id);

            service.Received().Delete(contact.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(contact.Id);

            Assert.Same(expected, actual);
        }
    }
}
