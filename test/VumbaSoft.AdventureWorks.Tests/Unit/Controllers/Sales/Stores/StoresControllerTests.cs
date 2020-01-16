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
    public class StoresControllerTests : ControllerTests
    {
        private StoresController controller;
        private IStoreValidator validator;
        private IStoreService service;
        private StoreView store;

        public StoresControllerTests()
        {
            validator = Substitute.For<IStoreValidator>();
            service = Substitute.For<IStoreService>();

            store = ObjectsFactory.CreateStoreView();

            controller = Substitute.ForPartsOf<StoresController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsStoreViews()
        {
            service.GetViews().Returns(Array.Empty<StoreView>().AsQueryable());

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
            validator.CanCreate(store).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(store)).Model;
            Object expected = store;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Store()
        {
            validator.CanCreate(store).Returns(true);

            controller.Create(store);

            service.Received().Create(store);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(store).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(store);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<StoreView>(store.Id).Returns(store);

            Object expected = NotEmptyView(controller, store);
            Object actual = controller.Details(store.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<StoreView>(store.Id).Returns(store);

            Object expected = NotEmptyView(controller, store);
            Object actual = controller.Edit(store.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(store).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(store)).Model;
            Object expected = store;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Store()
        {
            validator.CanEdit(store).Returns(true);

            controller.Edit(store);

            service.Received().Edit(store);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(store).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(store);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<StoreView>(store.Id).Returns(store);

            Object expected = NotEmptyView(controller, store);
            Object actual = controller.Delete(store.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesStore()
        {
            controller.DeleteConfirmed(store.Id);

            service.Received().Delete(store.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(store.Id);

            Assert.Same(expected, actual);
        }
    }
}
