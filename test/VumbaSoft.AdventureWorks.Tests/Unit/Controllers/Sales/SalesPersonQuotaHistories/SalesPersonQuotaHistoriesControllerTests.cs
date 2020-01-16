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
    public class SalesPersonQuotaHistoriesControllerTests : ControllerTests
    {
        private SalesPersonQuotaHistoriesController controller;
        private ISalesPersonQuotaHistoryValidator validator;
        private ISalesPersonQuotaHistoryService service;
        private SalesPersonQuotaHistoryView history;

        public SalesPersonQuotaHistoriesControllerTests()
        {
            validator = Substitute.For<ISalesPersonQuotaHistoryValidator>();
            service = Substitute.For<ISalesPersonQuotaHistoryService>();

            history = ObjectsFactory.CreateSalesPersonQuotaHistoryView();

            controller = Substitute.ForPartsOf<SalesPersonQuotaHistoriesController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsHistoryViews()
        {
            service.GetViews().Returns(Array.Empty<SalesPersonQuotaHistoryView>().AsQueryable());

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
            validator.CanCreate(history).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(history)).Model;
            Object expected = history;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_History()
        {
            validator.CanCreate(history).Returns(true);

            controller.Create(history);

            service.Received().Create(history);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(history).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(history);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<SalesPersonQuotaHistoryView>(history.Id).Returns(history);

            Object expected = NotEmptyView(controller, history);
            Object actual = controller.Details(history.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<SalesPersonQuotaHistoryView>(history.Id).Returns(history);

            Object expected = NotEmptyView(controller, history);
            Object actual = controller.Edit(history.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(history).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(history)).Model;
            Object expected = history;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_History()
        {
            validator.CanEdit(history).Returns(true);

            controller.Edit(history);

            service.Received().Edit(history);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(history).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(history);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<SalesPersonQuotaHistoryView>(history.Id).Returns(history);

            Object expected = NotEmptyView(controller, history);
            Object actual = controller.Delete(history.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesHistory()
        {
            controller.DeleteConfirmed(history.Id);

            service.Received().Delete(history.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(history.Id);

            Assert.Same(expected, actual);
        }
    }
}
