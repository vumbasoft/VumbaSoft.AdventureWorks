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
    public class ProductModelProductDescriptionCulturesControllerTests : ControllerTests
    {
        private ProductModelProductDescriptionCulturesController controller;
        private IProductModelProductDescriptionCultureValidator validator;
        private IProductModelProductDescriptionCultureService service;
        private ProductModelProductDescriptionCultureView culture;

        public ProductModelProductDescriptionCulturesControllerTests()
        {
            validator = Substitute.For<IProductModelProductDescriptionCultureValidator>();
            service = Substitute.For<IProductModelProductDescriptionCultureService>();

            culture = ObjectsFactory.CreateProductModelProductDescriptionCultureView();

            controller = Substitute.ForPartsOf<ProductModelProductDescriptionCulturesController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsCultureViews()
        {
            service.GetViews().Returns(Array.Empty<ProductModelProductDescriptionCultureView>().AsQueryable());

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
            validator.CanCreate(culture).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(culture)).Model;
            Object expected = culture;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Culture()
        {
            validator.CanCreate(culture).Returns(true);

            controller.Create(culture);

            service.Received().Create(culture);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(culture).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(culture);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<ProductModelProductDescriptionCultureView>(culture.Id).Returns(culture);

            Object expected = NotEmptyView(controller, culture);
            Object actual = controller.Details(culture.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<ProductModelProductDescriptionCultureView>(culture.Id).Returns(culture);

            Object expected = NotEmptyView(controller, culture);
            Object actual = controller.Edit(culture.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(culture).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(culture)).Model;
            Object expected = culture;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Culture()
        {
            validator.CanEdit(culture).Returns(true);

            controller.Edit(culture);

            service.Received().Edit(culture);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(culture).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(culture);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<ProductModelProductDescriptionCultureView>(culture.Id).Returns(culture);

            Object expected = NotEmptyView(controller, culture);
            Object actual = controller.Delete(culture.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesCulture()
        {
            controller.DeleteConfirmed(culture.Id);

            service.Received().Delete(culture.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(culture.Id);

            Assert.Same(expected, actual);
        }
    }
}
