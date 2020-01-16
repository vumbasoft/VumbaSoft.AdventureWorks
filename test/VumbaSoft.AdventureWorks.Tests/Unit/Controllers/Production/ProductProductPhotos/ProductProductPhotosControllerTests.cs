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
    public class ProductProductPhotosControllerTests : ControllerTests
    {
        private ProductProductPhotosController controller;
        private IProductProductPhotoValidator validator;
        private IProductProductPhotoService service;
        private ProductProductPhotoView photo;

        public ProductProductPhotosControllerTests()
        {
            validator = Substitute.For<IProductProductPhotoValidator>();
            service = Substitute.For<IProductProductPhotoService>();

            photo = ObjectsFactory.CreateProductProductPhotoView();

            controller = Substitute.ForPartsOf<ProductProductPhotosController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsPhotoViews()
        {
            service.GetViews().Returns(Array.Empty<ProductProductPhotoView>().AsQueryable());

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
            validator.CanCreate(photo).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(photo)).Model;
            Object expected = photo;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Photo()
        {
            validator.CanCreate(photo).Returns(true);

            controller.Create(photo);

            service.Received().Create(photo);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(photo).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(photo);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<ProductProductPhotoView>(photo.Id).Returns(photo);

            Object expected = NotEmptyView(controller, photo);
            Object actual = controller.Details(photo.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<ProductProductPhotoView>(photo.Id).Returns(photo);

            Object expected = NotEmptyView(controller, photo);
            Object actual = controller.Edit(photo.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(photo).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(photo)).Model;
            Object expected = photo;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Photo()
        {
            validator.CanEdit(photo).Returns(true);

            controller.Edit(photo);

            service.Received().Edit(photo);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(photo).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(photo);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<ProductProductPhotoView>(photo.Id).Returns(photo);

            Object expected = NotEmptyView(controller, photo);
            Object actual = controller.Delete(photo.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesPhoto()
        {
            controller.DeleteConfirmed(photo.Id);

            service.Received().Delete(photo.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(photo.Id);

            Assert.Same(expected, actual);
        }
    }
}
