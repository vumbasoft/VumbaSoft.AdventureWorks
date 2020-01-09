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

namespace VumbaSoft.AdventureWorks.Controllers.Demografic.Tests
{
    public class ContinentsControllerTests : ControllerTests
    {
        private ContinentsController controller;
        private IContinentValidator validator;
        private IContinentService service;
        private ContinentView continent;

        public ContinentsControllerTests()
        {
            validator = Substitute.For<IContinentValidator>();
            service = Substitute.For<IContinentService>();

            continent = ObjectsFactory.CreateContinentView();

            controller = Substitute.ForPartsOf<ContinentsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsContinentViews()
        {
            service.GetViews().Returns(Array.Empty<ContinentView>().AsQueryable());

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
            validator.CanCreate(continent).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(continent)).Model;
            Object expected = continent;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Continent()
        {
            validator.CanCreate(continent).Returns(true);

            controller.Create(continent);

            service.Received().Create(continent);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(continent).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(continent);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<ContinentView>(continent.Id).Returns(continent);

            Object expected = NotEmptyView(controller, continent);
            Object actual = controller.Details(continent.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<ContinentView>(continent.Id).Returns(continent);

            Object expected = NotEmptyView(controller, continent);
            Object actual = controller.Edit(continent.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(continent).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(continent)).Model;
            Object expected = continent;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Continent()
        {
            validator.CanEdit(continent).Returns(true);

            controller.Edit(continent);

            service.Received().Edit(continent);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(continent).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(continent);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<ContinentView>(continent.Id).Returns(continent);

            Object expected = NotEmptyView(controller, continent);
            Object actual = controller.Delete(continent.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesContinent()
        {
            controller.DeleteConfirmed(continent.Id);

            service.Received().Delete(continent.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(continent.Id);

            Assert.Same(expected, actual);
        }
    }
}
