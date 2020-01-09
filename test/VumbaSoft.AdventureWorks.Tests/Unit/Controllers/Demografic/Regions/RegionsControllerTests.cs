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
    public class RegionsControllerTests : ControllerTests
    {
        private RegionsController controller;
        private IRegionValidator validator;
        private IRegionService service;
        private RegionView region;

        public RegionsControllerTests()
        {
            validator = Substitute.For<IRegionValidator>();
            service = Substitute.For<IRegionService>();

            region = ObjectsFactory.CreateRegionView();

            controller = Substitute.ForPartsOf<RegionsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsRegionViews()
        {
            service.GetViews().Returns(Array.Empty<RegionView>().AsQueryable());

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
            validator.CanCreate(region).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(region)).Model;
            Object expected = region;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Region()
        {
            validator.CanCreate(region).Returns(true);

            controller.Create(region);

            service.Received().Create(region);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(region).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(region);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<RegionView>(region.Id).Returns(region);

            Object expected = NotEmptyView(controller, region);
            Object actual = controller.Details(region.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<RegionView>(region.Id).Returns(region);

            Object expected = NotEmptyView(controller, region);
            Object actual = controller.Edit(region.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(region).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(region)).Model;
            Object expected = region;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Region()
        {
            validator.CanEdit(region).Returns(true);

            controller.Edit(region);

            service.Received().Edit(region);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(region).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(region);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<RegionView>(region.Id).Returns(region);

            Object expected = NotEmptyView(controller, region);
            Object actual = controller.Delete(region.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesRegion()
        {
            controller.DeleteConfirmed(region.Id);

            service.Received().Delete(region.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(region.Id);

            Assert.Same(expected, actual);
        }
    }
}
