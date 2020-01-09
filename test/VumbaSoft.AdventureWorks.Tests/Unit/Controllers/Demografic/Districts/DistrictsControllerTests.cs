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
    public class DistrictsControllerTests : ControllerTests
    {
        private DistrictsController controller;
        private IDistrictValidator validator;
        private IDistrictService service;
        private DistrictView district;

        public DistrictsControllerTests()
        {
            validator = Substitute.For<IDistrictValidator>();
            service = Substitute.For<IDistrictService>();

            district = ObjectsFactory.CreateDistrictView();

            controller = Substitute.ForPartsOf<DistrictsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsDistrictViews()
        {
            service.GetViews().Returns(Array.Empty<DistrictView>().AsQueryable());

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
            validator.CanCreate(district).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(district)).Model;
            Object expected = district;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_District()
        {
            validator.CanCreate(district).Returns(true);

            controller.Create(district);

            service.Received().Create(district);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(district).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(district);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<DistrictView>(district.Id).Returns(district);

            Object expected = NotEmptyView(controller, district);
            Object actual = controller.Details(district.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<DistrictView>(district.Id).Returns(district);

            Object expected = NotEmptyView(controller, district);
            Object actual = controller.Edit(district.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(district).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(district)).Model;
            Object expected = district;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_District()
        {
            validator.CanEdit(district).Returns(true);

            controller.Edit(district);

            service.Received().Edit(district);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(district).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(district);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<DistrictView>(district.Id).Returns(district);

            Object expected = NotEmptyView(controller, district);
            Object actual = controller.Delete(district.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesDistrict()
        {
            controller.DeleteConfirmed(district.Id);

            service.Received().Delete(district.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(district.Id);

            Assert.Same(expected, actual);
        }
    }
}
