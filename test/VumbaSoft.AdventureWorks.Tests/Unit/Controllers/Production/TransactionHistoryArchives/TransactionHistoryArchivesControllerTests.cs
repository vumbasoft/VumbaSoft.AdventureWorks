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
    public class TransactionHistoryArchivesControllerTests : ControllerTests
    {
        private TransactionHistoryArchivesController controller;
        private ITransactionHistoryArchiveValidator validator;
        private ITransactionHistoryArchiveService service;
        private TransactionHistoryArchiveView archive;

        public TransactionHistoryArchivesControllerTests()
        {
            validator = Substitute.For<ITransactionHistoryArchiveValidator>();
            service = Substitute.For<ITransactionHistoryArchiveService>();

            archive = ObjectsFactory.CreateTransactionHistoryArchiveView();

            controller = Substitute.ForPartsOf<TransactionHistoryArchivesController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsArchiveViews()
        {
            service.GetViews().Returns(Array.Empty<TransactionHistoryArchiveView>().AsQueryable());

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
            validator.CanCreate(archive).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(archive)).Model;
            Object expected = archive;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Archive()
        {
            validator.CanCreate(archive).Returns(true);

            controller.Create(archive);

            service.Received().Create(archive);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(archive).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(archive);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<TransactionHistoryArchiveView>(archive.Id).Returns(archive);

            Object expected = NotEmptyView(controller, archive);
            Object actual = controller.Details(archive.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<TransactionHistoryArchiveView>(archive.Id).Returns(archive);

            Object expected = NotEmptyView(controller, archive);
            Object actual = controller.Edit(archive.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(archive).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(archive)).Model;
            Object expected = archive;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Archive()
        {
            validator.CanEdit(archive).Returns(true);

            controller.Edit(archive);

            service.Received().Edit(archive);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(archive).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(archive);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<TransactionHistoryArchiveView>(archive.Id).Returns(archive);

            Object expected = NotEmptyView(controller, archive);
            Object actual = controller.Delete(archive.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesArchive()
        {
            controller.DeleteConfirmed(archive.Id);

            service.Received().Delete(archive.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(archive.Id);

            Assert.Same(expected, actual);
        }
    }
}
