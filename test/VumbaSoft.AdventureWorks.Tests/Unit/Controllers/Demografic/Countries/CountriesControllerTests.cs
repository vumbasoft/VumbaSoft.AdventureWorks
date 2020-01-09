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
    public class CountriesControllerTests : ControllerTests
    {
        private CountriesController controller;
        private ICountryValidator validator;
        private ICountryService service;
        private CountryView country;

        public CountriesControllerTests()
        {
            validator = Substitute.For<ICountryValidator>();
            service = Substitute.For<ICountryService>();

            country = ObjectsFactory.CreateCountryView();

            controller = Substitute.ForPartsOf<CountriesController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsCountryViews()
        {
            service.GetViews().Returns(Array.Empty<CountryView>().AsQueryable());

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
            validator.CanCreate(country).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(country)).Model;
            Object expected = country;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Country()
        {
            validator.CanCreate(country).Returns(true);

            controller.Create(country);

            service.Received().Create(country);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(country).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(country);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<CountryView>(country.Id).Returns(country);

            Object expected = NotEmptyView(controller, country);
            Object actual = controller.Details(country.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<CountryView>(country.Id).Returns(country);

            Object expected = NotEmptyView(controller, country);
            Object actual = controller.Edit(country.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(country).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(country)).Model;
            Object expected = country;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Country()
        {
            validator.CanEdit(country).Returns(true);

            controller.Edit(country);

            service.Received().Edit(country);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(country).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(country);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<CountryView>(country.Id).Returns(country);

            Object expected = NotEmptyView(controller, country);
            Object actual = controller.Delete(country.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesCountry()
        {
            controller.DeleteConfirmed(country.Id);

            service.Received().Delete(country.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(country.Id);

            Assert.Same(expected, actual);
        }
    }
}
