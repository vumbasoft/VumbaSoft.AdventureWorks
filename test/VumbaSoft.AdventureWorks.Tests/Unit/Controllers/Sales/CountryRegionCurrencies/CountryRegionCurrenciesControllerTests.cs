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
    public class CountryRegionCurrenciesControllerTests : ControllerTests
    {
        private CountryRegionCurrenciesController controller;
        private ICountryRegionCurrencyValidator validator;
        private ICountryRegionCurrencyService service;
        private CountryRegionCurrencyView currency;

        public CountryRegionCurrenciesControllerTests()
        {
            validator = Substitute.For<ICountryRegionCurrencyValidator>();
            service = Substitute.For<ICountryRegionCurrencyService>();

            currency = ObjectsFactory.CreateCountryRegionCurrencyView();

            controller = Substitute.ForPartsOf<CountryRegionCurrenciesController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsCurrencyViews()
        {
            service.GetViews().Returns(Array.Empty<CountryRegionCurrencyView>().AsQueryable());

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
            validator.CanCreate(currency).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(currency)).Model;
            Object expected = currency;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Currency()
        {
            validator.CanCreate(currency).Returns(true);

            controller.Create(currency);

            service.Received().Create(currency);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(currency).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(currency);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<CountryRegionCurrencyView>(currency.Id).Returns(currency);

            Object expected = NotEmptyView(controller, currency);
            Object actual = controller.Details(currency.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<CountryRegionCurrencyView>(currency.Id).Returns(currency);

            Object expected = NotEmptyView(controller, currency);
            Object actual = controller.Edit(currency.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(currency).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(currency)).Model;
            Object expected = currency;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Currency()
        {
            validator.CanEdit(currency).Returns(true);

            controller.Edit(currency);

            service.Received().Edit(currency);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(currency).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(currency);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<CountryRegionCurrencyView>(currency.Id).Returns(currency);

            Object expected = NotEmptyView(controller, currency);
            Object actual = controller.Delete(currency.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesCurrency()
        {
            controller.DeleteConfirmed(currency.Id);

            service.Received().Delete(currency.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(currency.Id);

            Assert.Same(expected, actual);
        }
    }
}
