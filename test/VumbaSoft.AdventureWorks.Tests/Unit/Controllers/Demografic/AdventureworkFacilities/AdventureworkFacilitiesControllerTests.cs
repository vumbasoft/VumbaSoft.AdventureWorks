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
    public class AdventureworkFacilitiesControllerTests : ControllerTests
    {
        private AdventureworkFacilitiesController controller;
        private IAdventureworkFacilityValidator validator;
        private IAdventureworkFacilityService service;
        private AdventureworkFacilityView facility;

        public AdventureworkFacilitiesControllerTests()
        {
            validator = Substitute.For<IAdventureworkFacilityValidator>();
            service = Substitute.For<IAdventureworkFacilityService>();

            facility = ObjectsFactory.CreateAdventureworkFacilityView();

            controller = Substitute.ForPartsOf<AdventureworkFacilitiesController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsFacilityViews()
        {
            service.GetViews().Returns(Array.Empty<AdventureworkFacilityView>().AsQueryable());

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
            validator.CanCreate(facility).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(facility)).Model;
            Object expected = facility;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Facility()
        {
            validator.CanCreate(facility).Returns(true);

            controller.Create(facility);

            service.Received().Create(facility);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(facility).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(facility);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<AdventureworkFacilityView>(facility.Id).Returns(facility);

            Object expected = NotEmptyView(controller, facility);
            Object actual = controller.Details(facility.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<AdventureworkFacilityView>(facility.Id).Returns(facility);

            Object expected = NotEmptyView(controller, facility);
            Object actual = controller.Edit(facility.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(facility).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(facility)).Model;
            Object expected = facility;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Facility()
        {
            validator.CanEdit(facility).Returns(true);

            controller.Edit(facility);

            service.Received().Edit(facility);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(facility).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(facility);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<AdventureworkFacilityView>(facility.Id).Returns(facility);

            Object expected = NotEmptyView(controller, facility);
            Object actual = controller.Delete(facility.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesFacility()
        {
            controller.DeleteConfirmed(facility.Id);

            service.Received().Delete(facility.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(facility.Id);

            Assert.Same(expected, actual);
        }
    }
}
