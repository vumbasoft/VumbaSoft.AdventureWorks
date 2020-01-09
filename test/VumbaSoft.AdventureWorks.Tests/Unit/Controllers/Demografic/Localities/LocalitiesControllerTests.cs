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
    public class LocalitiesControllerTests : ControllerTests
    {
        private LocalitiesController controller;
        private ILocalityValidator validator;
        private ILocalityService service;
        private LocalityView locality;

        public LocalitiesControllerTests()
        {
            validator = Substitute.For<ILocalityValidator>();
            service = Substitute.For<ILocalityService>();

            locality = ObjectsFactory.CreateLocalityView();

            controller = Substitute.ForPartsOf<LocalitiesController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsLocalityViews()
        {
            service.GetViews().Returns(Array.Empty<LocalityView>().AsQueryable());

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
            validator.CanCreate(locality).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(locality)).Model;
            Object expected = locality;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Locality()
        {
            validator.CanCreate(locality).Returns(true);

            controller.Create(locality);

            service.Received().Create(locality);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(locality).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(locality);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<LocalityView>(locality.Id).Returns(locality);

            Object expected = NotEmptyView(controller, locality);
            Object actual = controller.Details(locality.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<LocalityView>(locality.Id).Returns(locality);

            Object expected = NotEmptyView(controller, locality);
            Object actual = controller.Edit(locality.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(locality).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(locality)).Model;
            Object expected = locality;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Locality()
        {
            validator.CanEdit(locality).Returns(true);

            controller.Edit(locality);

            service.Received().Edit(locality);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(locality).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(locality);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<LocalityView>(locality.Id).Returns(locality);

            Object expected = NotEmptyView(controller, locality);
            Object actual = controller.Delete(locality.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesLocality()
        {
            controller.DeleteConfirmed(locality.Id);

            service.Received().Delete(locality.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(locality.Id);

            Assert.Same(expected, actual);
        }
    }
}
