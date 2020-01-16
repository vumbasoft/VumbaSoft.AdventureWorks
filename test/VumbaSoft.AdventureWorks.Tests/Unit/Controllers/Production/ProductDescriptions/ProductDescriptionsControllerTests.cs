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
    public class ProductDescriptionsControllerTests : ControllerTests
    {
        private ProductDescriptionsController controller;
        private IProductDescriptionValidator validator;
        private IProductDescriptionService service;
        private ProductDescriptionView description;

        public ProductDescriptionsControllerTests()
        {
            validator = Substitute.For<IProductDescriptionValidator>();
            service = Substitute.For<IProductDescriptionService>();

            description = ObjectsFactory.CreateProductDescriptionView();

            controller = Substitute.ForPartsOf<ProductDescriptionsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsDescriptionViews()
        {
            service.GetViews().Returns(Array.Empty<ProductDescriptionView>().AsQueryable());

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
            validator.CanCreate(description).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(description)).Model;
            Object expected = description;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Description()
        {
            validator.CanCreate(description).Returns(true);

            controller.Create(description);

            service.Received().Create(description);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(description).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(description);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<ProductDescriptionView>(description.Id).Returns(description);

            Object expected = NotEmptyView(controller, description);
            Object actual = controller.Details(description.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<ProductDescriptionView>(description.Id).Returns(description);

            Object expected = NotEmptyView(controller, description);
            Object actual = controller.Edit(description.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(description).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(description)).Model;
            Object expected = description;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Description()
        {
            validator.CanEdit(description).Returns(true);

            controller.Edit(description);

            service.Received().Edit(description);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(description).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(description);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<ProductDescriptionView>(description.Id).Returns(description);

            Object expected = NotEmptyView(controller, description);
            Object actual = controller.Delete(description.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesDescription()
        {
            controller.DeleteConfirmed(description.Id);

            service.Received().Delete(description.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(description.Id);

            Assert.Same(expected, actual);
        }
    }
}
