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

namespace VumbaSoft.AdventureWorks.Controllers.Sales.Tests
{
    public class SpecialOfferProductsControllerTests : ControllerTests
    {
        private SpecialOfferProductsController controller;
        private ISpecialOfferProductValidator validator;
        private ISpecialOfferProductService service;
        private SpecialOfferProductView product;

        public SpecialOfferProductsControllerTests()
        {
            validator = Substitute.For<ISpecialOfferProductValidator>();
            service = Substitute.For<ISpecialOfferProductService>();

            product = ObjectsFactory.CreateSpecialOfferProductView();

            controller = Substitute.ForPartsOf<SpecialOfferProductsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsProductViews()
        {
            service.GetViews().Returns(Array.Empty<SpecialOfferProductView>().AsQueryable());

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
            validator.CanCreate(product).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(product)).Model;
            Object expected = product;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Product()
        {
            validator.CanCreate(product).Returns(true);

            controller.Create(product);

            service.Received().Create(product);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(product).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(product);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<SpecialOfferProductView>(product.Id).Returns(product);

            Object expected = NotEmptyView(controller, product);
            Object actual = controller.Details(product.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<SpecialOfferProductView>(product.Id).Returns(product);

            Object expected = NotEmptyView(controller, product);
            Object actual = controller.Edit(product.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(product).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(product)).Model;
            Object expected = product;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Product()
        {
            validator.CanEdit(product).Returns(true);

            controller.Edit(product);

            service.Received().Edit(product);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(product).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(product);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<SpecialOfferProductView>(product.Id).Returns(product);

            Object expected = NotEmptyView(controller, product);
            Object actual = controller.Delete(product.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesProduct()
        {
            controller.DeleteConfirmed(product.Id);

            service.Received().Delete(product.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(product.Id);

            Assert.Same(expected, actual);
        }
    }
}
