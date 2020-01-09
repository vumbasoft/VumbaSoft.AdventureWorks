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
    public class CitiesControllerTests : ControllerTests
    {
        private CitiesController controller;
        private ICityValidator validator;
        private ICityService service;
        private CityView city;

        public CitiesControllerTests()
        {
            validator = Substitute.For<ICityValidator>();
            service = Substitute.For<ICityService>();

            city = ObjectsFactory.CreateCityView();

            controller = Substitute.ForPartsOf<CitiesController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsCityViews()
        {
            service.GetViews().Returns(Array.Empty<CityView>().AsQueryable());

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
            validator.CanCreate(city).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(city)).Model;
            Object expected = city;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_City()
        {
            validator.CanCreate(city).Returns(true);

            controller.Create(city);

            service.Received().Create(city);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(city).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(city);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<CityView>(city.Id).Returns(city);

            Object expected = NotEmptyView(controller, city);
            Object actual = controller.Details(city.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<CityView>(city.Id).Returns(city);

            Object expected = NotEmptyView(controller, city);
            Object actual = controller.Edit(city.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(city).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(city)).Model;
            Object expected = city;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_City()
        {
            validator.CanEdit(city).Returns(true);

            controller.Edit(city);

            service.Received().Edit(city);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(city).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(city);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<CityView>(city.Id).Returns(city);

            Object expected = NotEmptyView(controller, city);
            Object actual = controller.Delete(city.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesCity()
        {
            controller.DeleteConfirmed(city.Id);

            service.Received().Delete(city.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(city.Id);

            Assert.Same(expected, actual);
        }
    }
}
