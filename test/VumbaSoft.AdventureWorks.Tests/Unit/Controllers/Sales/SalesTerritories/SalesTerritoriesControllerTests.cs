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
    public class SalesTerritoriesControllerTests : ControllerTests
    {
        private SalesTerritoriesController controller;
        private ISalesTerritoryValidator validator;
        private ISalesTerritoryService service;
        private SalesTerritoryView territory;

        public SalesTerritoriesControllerTests()
        {
            validator = Substitute.For<ISalesTerritoryValidator>();
            service = Substitute.For<ISalesTerritoryService>();

            territory = ObjectsFactory.CreateSalesTerritoryView();

            controller = Substitute.ForPartsOf<SalesTerritoriesController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsTerritoryViews()
        {
            service.GetViews().Returns(Array.Empty<SalesTerritoryView>().AsQueryable());

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
            validator.CanCreate(territory).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(territory)).Model;
            Object expected = territory;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Territory()
        {
            validator.CanCreate(territory).Returns(true);

            controller.Create(territory);

            service.Received().Create(territory);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(territory).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(territory);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<SalesTerritoryView>(territory.Id).Returns(territory);

            Object expected = NotEmptyView(controller, territory);
            Object actual = controller.Details(territory.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<SalesTerritoryView>(territory.Id).Returns(territory);

            Object expected = NotEmptyView(controller, territory);
            Object actual = controller.Edit(territory.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(territory).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(territory)).Model;
            Object expected = territory;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Territory()
        {
            validator.CanEdit(territory).Returns(true);

            controller.Edit(territory);

            service.Received().Edit(territory);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(territory).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(territory);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<SalesTerritoryView>(territory.Id).Returns(territory);

            Object expected = NotEmptyView(controller, territory);
            Object actual = controller.Delete(territory.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesTerritory()
        {
            controller.DeleteConfirmed(territory.Id);

            service.Received().Delete(territory.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(territory.Id);

            Assert.Same(expected, actual);
        }
    }
}
