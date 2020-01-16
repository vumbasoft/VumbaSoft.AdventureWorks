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
    public class CurrencyRatesControllerTests : ControllerTests
    {
        private CurrencyRatesController controller;
        private ICurrencyRateValidator validator;
        private ICurrencyRateService service;
        private CurrencyRateView rate;

        public CurrencyRatesControllerTests()
        {
            validator = Substitute.For<ICurrencyRateValidator>();
            service = Substitute.For<ICurrencyRateService>();

            rate = ObjectsFactory.CreateCurrencyRateView();

            controller = Substitute.ForPartsOf<CurrencyRatesController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsRateViews()
        {
            service.GetViews().Returns(Array.Empty<CurrencyRateView>().AsQueryable());

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
            validator.CanCreate(rate).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(rate)).Model;
            Object expected = rate;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Rate()
        {
            validator.CanCreate(rate).Returns(true);

            controller.Create(rate);

            service.Received().Create(rate);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(rate).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(rate);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<CurrencyRateView>(rate.Id).Returns(rate);

            Object expected = NotEmptyView(controller, rate);
            Object actual = controller.Details(rate.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<CurrencyRateView>(rate.Id).Returns(rate);

            Object expected = NotEmptyView(controller, rate);
            Object actual = controller.Edit(rate.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(rate).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(rate)).Model;
            Object expected = rate;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Rate()
        {
            validator.CanEdit(rate).Returns(true);

            controller.Edit(rate);

            service.Received().Edit(rate);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(rate).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(rate);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<CurrencyRateView>(rate.Id).Returns(rate);

            Object expected = NotEmptyView(controller, rate);
            Object actual = controller.Delete(rate.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesRate()
        {
            controller.DeleteConfirmed(rate.Id);

            service.Received().Delete(rate.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(rate.Id);

            Assert.Same(expected, actual);
        }
    }
}
