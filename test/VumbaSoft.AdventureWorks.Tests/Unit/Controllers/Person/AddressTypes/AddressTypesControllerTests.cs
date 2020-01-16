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

namespace VumbaSoft.AdventureWorks.Controllers.Person.Tests
{
    public class AddressTypesControllerTests : ControllerTests
    {
        private AddressTypesController controller;
        private IAddresstypeValidator validator;
        private IAddresstypeService service;
        private AddresstypeView addresstype;

        public AddressTypesControllerTests()
        {
            validator = Substitute.For<IAddresstypeValidator>();
            service = Substitute.For<IAddresstypeService>();

            addresstype = ObjectsFactory.CreateAddresstypeView();

            controller = Substitute.ForPartsOf<AddressTypesController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsAddresstypeViews()
        {
            service.GetViews().Returns(Array.Empty<AddresstypeView>().AsQueryable());

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
            validator.CanCreate(addresstype).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(addresstype)).Model;
            Object expected = addresstype;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Addresstype()
        {
            validator.CanCreate(addresstype).Returns(true);

            controller.Create(addresstype);

            service.Received().Create(addresstype);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(addresstype).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(addresstype);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<AddresstypeView>(addresstype.Id).Returns(addresstype);

            Object expected = NotEmptyView(controller, addresstype);
            Object actual = controller.Details(addresstype.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<AddresstypeView>(addresstype.Id).Returns(addresstype);

            Object expected = NotEmptyView(controller, addresstype);
            Object actual = controller.Edit(addresstype.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(addresstype).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(addresstype)).Model;
            Object expected = addresstype;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Addresstype()
        {
            validator.CanEdit(addresstype).Returns(true);

            controller.Edit(addresstype);

            service.Received().Edit(addresstype);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(addresstype).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(addresstype);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<AddresstypeView>(addresstype.Id).Returns(addresstype);

            Object expected = NotEmptyView(controller, addresstype);
            Object actual = controller.Delete(addresstype.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesAddresstype()
        {
            controller.DeleteConfirmed(addresstype.Id);

            service.Received().Delete(addresstype.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(addresstype.Id);

            Assert.Same(expected, actual);
        }
    }
}
