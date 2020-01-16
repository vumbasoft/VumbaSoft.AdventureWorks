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
    public class SalesPersonsControllerTests : ControllerTests
    {
        private SalesPersonsController controller;
        private ISalesPersonValidator validator;
        private ISalesPersonService service;
        private SalesPersonView person;

        public SalesPersonsControllerTests()
        {
            validator = Substitute.For<ISalesPersonValidator>();
            service = Substitute.For<ISalesPersonService>();

            person = ObjectsFactory.CreateSalesPersonView();

            controller = Substitute.ForPartsOf<SalesPersonsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsPersonViews()
        {
            service.GetViews().Returns(Array.Empty<SalesPersonView>().AsQueryable());

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
            validator.CanCreate(person).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(person)).Model;
            Object expected = person;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Person()
        {
            validator.CanCreate(person).Returns(true);

            controller.Create(person);

            service.Received().Create(person);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(person).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(person);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<SalesPersonView>(person.Id).Returns(person);

            Object expected = NotEmptyView(controller, person);
            Object actual = controller.Details(person.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<SalesPersonView>(person.Id).Returns(person);

            Object expected = NotEmptyView(controller, person);
            Object actual = controller.Edit(person.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(person).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(person)).Model;
            Object expected = person;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Person()
        {
            validator.CanEdit(person).Returns(true);

            controller.Edit(person);

            service.Received().Edit(person);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(person).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(person);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<SalesPersonView>(person.Id).Returns(person);

            Object expected = NotEmptyView(controller, person);
            Object actual = controller.Delete(person.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesPerson()
        {
            controller.DeleteConfirmed(person.Id);

            service.Received().Delete(person.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(person.Id);

            Assert.Same(expected, actual);
        }
    }
}
