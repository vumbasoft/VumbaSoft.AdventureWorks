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

namespace VumbaSoft.AdventureWorks.Controllers.Production.Tests
{
    public class LocationsControllerTests : ControllerTests
    {
        private LocationsController controller;
        private ILocationValidator validator;
        private ILocationService service;
        private LocationView location;

        public LocationsControllerTests()
        {
            validator = Substitute.For<ILocationValidator>();
            service = Substitute.For<ILocationService>();

            location = ObjectsFactory.CreateLocationView();

            controller = Substitute.ForPartsOf<LocationsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsLocationViews()
        {
            service.GetViews().Returns(Array.Empty<LocationView>().AsQueryable());

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
            validator.CanCreate(location).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(location)).Model;
            Object expected = location;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Location()
        {
            validator.CanCreate(location).Returns(true);

            controller.Create(location);

            service.Received().Create(location);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(location).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(location);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<LocationView>(location.Id).Returns(location);

            Object expected = NotEmptyView(controller, location);
            Object actual = controller.Details(location.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<LocationView>(location.Id).Returns(location);

            Object expected = NotEmptyView(controller, location);
            Object actual = controller.Edit(location.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(location).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(location)).Model;
            Object expected = location;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Location()
        {
            validator.CanEdit(location).Returns(true);

            controller.Edit(location);

            service.Received().Edit(location);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(location).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(location);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<LocationView>(location.Id).Returns(location);

            Object expected = NotEmptyView(controller, location);
            Object actual = controller.Delete(location.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesLocation()
        {
            controller.DeleteConfirmed(location.Id);

            service.Received().Delete(location.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(location.Id);

            Assert.Same(expected, actual);
        }
    }
}
