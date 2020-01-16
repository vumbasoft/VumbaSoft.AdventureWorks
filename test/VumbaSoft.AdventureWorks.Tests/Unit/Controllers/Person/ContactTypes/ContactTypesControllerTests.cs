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
    public class ContactTypesControllerTests : ControllerTests
    {
        private ContactTypesController controller;
        private IContactTypeValidator validator;
        private IContactTypeService service;
        private ContactTypeView type;

        public ContactTypesControllerTests()
        {
            validator = Substitute.For<IContactTypeValidator>();
            service = Substitute.For<IContactTypeService>();

            type = ObjectsFactory.CreateContactTypeView();

            controller = Substitute.ForPartsOf<ContactTypesController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsTypeViews()
        {
            service.GetViews().Returns(Array.Empty<ContactTypeView>().AsQueryable());

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
            validator.CanCreate(type).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(type)).Model;
            Object expected = type;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Type()
        {
            validator.CanCreate(type).Returns(true);

            controller.Create(type);

            service.Received().Create(type);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(type).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(type);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<ContactTypeView>(type.Id).Returns(type);

            Object expected = NotEmptyView(controller, type);
            Object actual = controller.Details(type.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<ContactTypeView>(type.Id).Returns(type);

            Object expected = NotEmptyView(controller, type);
            Object actual = controller.Edit(type.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(type).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(type)).Model;
            Object expected = type;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Type()
        {
            validator.CanEdit(type).Returns(true);

            controller.Edit(type);

            service.Received().Edit(type);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(type).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(type);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<ContactTypeView>(type.Id).Returns(type);

            Object expected = NotEmptyView(controller, type);
            Object actual = controller.Delete(type.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesType()
        {
            controller.DeleteConfirmed(type.Id);

            service.Received().Delete(type.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(type.Id);

            Assert.Same(expected, actual);
        }
    }
}
