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
    public class ProductModelsControllerTests : ControllerTests
    {
        private ProductModelsController controller;
        private IProductModelValidator validator;
        private IProductModelService service;
        private ProductModelView model;

        public ProductModelsControllerTests()
        {
            validator = Substitute.For<IProductModelValidator>();
            service = Substitute.For<IProductModelService>();

            model = ObjectsFactory.CreateProductModelView();

            controller = Substitute.ForPartsOf<ProductModelsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsModelViews()
        {
            service.GetViews().Returns(Array.Empty<ProductModelView>().AsQueryable());

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
            validator.CanCreate(model).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(model)).Model;
            Object expected = model;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Model()
        {
            validator.CanCreate(model).Returns(true);

            controller.Create(model);

            service.Received().Create(model);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(model).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(model);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<ProductModelView>(model.Id).Returns(model);

            Object expected = NotEmptyView(controller, model);
            Object actual = controller.Details(model.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<ProductModelView>(model.Id).Returns(model);

            Object expected = NotEmptyView(controller, model);
            Object actual = controller.Edit(model.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(model).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(model)).Model;
            Object expected = model;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Model()
        {
            validator.CanEdit(model).Returns(true);

            controller.Edit(model);

            service.Received().Edit(model);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(model).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(model);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<ProductModelView>(model.Id).Returns(model);

            Object expected = NotEmptyView(controller, model);
            Object actual = controller.Delete(model.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesModel()
        {
            controller.DeleteConfirmed(model.Id);

            service.Received().Delete(model.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(model.Id);

            Assert.Same(expected, actual);
        }
    }
}
