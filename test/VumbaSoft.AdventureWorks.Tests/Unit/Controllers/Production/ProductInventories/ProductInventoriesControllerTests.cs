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
    public class ProductInventoriesControllerTests : ControllerTests
    {
        private ProductInventoriesController controller;
        private IProductInventoryValidator validator;
        private IProductInventoryService service;
        private ProductInventoryView inventory;

        public ProductInventoriesControllerTests()
        {
            validator = Substitute.For<IProductInventoryValidator>();
            service = Substitute.For<IProductInventoryService>();

            inventory = ObjectsFactory.CreateProductInventoryView();

            controller = Substitute.ForPartsOf<ProductInventoriesController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsInventoryViews()
        {
            service.GetViews().Returns(Array.Empty<ProductInventoryView>().AsQueryable());

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
            validator.CanCreate(inventory).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(inventory)).Model;
            Object expected = inventory;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Inventory()
        {
            validator.CanCreate(inventory).Returns(true);

            controller.Create(inventory);

            service.Received().Create(inventory);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(inventory).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(inventory);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<ProductInventoryView>(inventory.Id).Returns(inventory);

            Object expected = NotEmptyView(controller, inventory);
            Object actual = controller.Details(inventory.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<ProductInventoryView>(inventory.Id).Returns(inventory);

            Object expected = NotEmptyView(controller, inventory);
            Object actual = controller.Edit(inventory.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(inventory).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(inventory)).Model;
            Object expected = inventory;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Inventory()
        {
            validator.CanEdit(inventory).Returns(true);

            controller.Edit(inventory);

            service.Received().Edit(inventory);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(inventory).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(inventory);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<ProductInventoryView>(inventory.Id).Returns(inventory);

            Object expected = NotEmptyView(controller, inventory);
            Object actual = controller.Delete(inventory.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesInventory()
        {
            controller.DeleteConfirmed(inventory.Id);

            service.Received().Delete(inventory.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(inventory.Id);

            Assert.Same(expected, actual);
        }
    }
}
