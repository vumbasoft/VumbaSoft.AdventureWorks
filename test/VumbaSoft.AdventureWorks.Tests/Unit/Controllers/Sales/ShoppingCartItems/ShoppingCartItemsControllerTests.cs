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
    public class ShoppingCartItemsControllerTests : ControllerTests
    {
        private ShoppingCartItemsController controller;
        private IShoppingCartItemValidator validator;
        private IShoppingCartItemService service;
        private ShoppingCartItemView item;

        public ShoppingCartItemsControllerTests()
        {
            validator = Substitute.For<IShoppingCartItemValidator>();
            service = Substitute.For<IShoppingCartItemService>();

            item = ObjectsFactory.CreateShoppingCartItemView();

            controller = Substitute.ForPartsOf<ShoppingCartItemsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsItemViews()
        {
            service.GetViews().Returns(Array.Empty<ShoppingCartItemView>().AsQueryable());

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
            validator.CanCreate(item).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(item)).Model;
            Object expected = item;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Item()
        {
            validator.CanCreate(item).Returns(true);

            controller.Create(item);

            service.Received().Create(item);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(item).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(item);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<ShoppingCartItemView>(item.Id).Returns(item);

            Object expected = NotEmptyView(controller, item);
            Object actual = controller.Details(item.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<ShoppingCartItemView>(item.Id).Returns(item);

            Object expected = NotEmptyView(controller, item);
            Object actual = controller.Edit(item.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(item).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(item)).Model;
            Object expected = item;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Item()
        {
            validator.CanEdit(item).Returns(true);

            controller.Edit(item);

            service.Received().Edit(item);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(item).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(item);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<ShoppingCartItemView>(item.Id).Returns(item);

            Object expected = NotEmptyView(controller, item);
            Object actual = controller.Delete(item.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesItem()
        {
            controller.DeleteConfirmed(item.Id);

            service.Received().Delete(item.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(item.Id);

            Assert.Same(expected, actual);
        }
    }
}
