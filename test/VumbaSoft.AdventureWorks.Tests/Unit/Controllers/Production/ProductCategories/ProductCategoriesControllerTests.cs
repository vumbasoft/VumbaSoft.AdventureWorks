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
    public class ProductCategoriesControllerTests : ControllerTests
    {
        private ProductCategoriesController controller;
        private IProductCategoryValidator validator;
        private IProductCategoryService service;
        private ProductCategoryView category;

        public ProductCategoriesControllerTests()
        {
            validator = Substitute.For<IProductCategoryValidator>();
            service = Substitute.For<IProductCategoryService>();

            category = ObjectsFactory.CreateProductCategoryView();

            controller = Substitute.ForPartsOf<ProductCategoriesController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsCategoryViews()
        {
            service.GetViews().Returns(Array.Empty<ProductCategoryView>().AsQueryable());

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
            validator.CanCreate(category).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(category)).Model;
            Object expected = category;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Category()
        {
            validator.CanCreate(category).Returns(true);

            controller.Create(category);

            service.Received().Create(category);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(category).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(category);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<ProductCategoryView>(category.Id).Returns(category);

            Object expected = NotEmptyView(controller, category);
            Object actual = controller.Details(category.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<ProductCategoryView>(category.Id).Returns(category);

            Object expected = NotEmptyView(controller, category);
            Object actual = controller.Edit(category.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(category).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(category)).Model;
            Object expected = category;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Category()
        {
            validator.CanEdit(category).Returns(true);

            controller.Edit(category);

            service.Received().Edit(category);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(category).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(category);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<ProductCategoryView>(category.Id).Returns(category);

            Object expected = NotEmptyView(controller, category);
            Object actual = controller.Delete(category.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesCategory()
        {
            controller.DeleteConfirmed(category.Id);

            service.Received().Delete(category.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(category.Id);

            Assert.Same(expected, actual);
        }
    }
}
