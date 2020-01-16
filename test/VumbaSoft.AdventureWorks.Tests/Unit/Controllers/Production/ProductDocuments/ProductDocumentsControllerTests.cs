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
    public class ProductDocumentsControllerTests : ControllerTests
    {
        private ProductDocumentsController controller;
        private IProductDocumentValidator validator;
        private IProductDocumentService service;
        private ProductDocumentView document;

        public ProductDocumentsControllerTests()
        {
            validator = Substitute.For<IProductDocumentValidator>();
            service = Substitute.For<IProductDocumentService>();

            document = ObjectsFactory.CreateProductDocumentView();

            controller = Substitute.ForPartsOf<ProductDocumentsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsDocumentViews()
        {
            service.GetViews().Returns(Array.Empty<ProductDocumentView>().AsQueryable());

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
            validator.CanCreate(document).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(document)).Model;
            Object expected = document;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Document()
        {
            validator.CanCreate(document).Returns(true);

            controller.Create(document);

            service.Received().Create(document);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(document).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(document);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<ProductDocumentView>(document.Id).Returns(document);

            Object expected = NotEmptyView(controller, document);
            Object actual = controller.Details(document.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<ProductDocumentView>(document.Id).Returns(document);

            Object expected = NotEmptyView(controller, document);
            Object actual = controller.Edit(document.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(document).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(document)).Model;
            Object expected = document;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Document()
        {
            validator.CanEdit(document).Returns(true);

            controller.Edit(document);

            service.Received().Edit(document);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(document).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(document);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<ProductDocumentView>(document.Id).Returns(document);

            Object expected = NotEmptyView(controller, document);
            Object actual = controller.Delete(document.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesDocument()
        {
            controller.DeleteConfirmed(document.Id);

            service.Received().Delete(document.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(document.Id);

            Assert.Same(expected, actual);
        }
    }
}
