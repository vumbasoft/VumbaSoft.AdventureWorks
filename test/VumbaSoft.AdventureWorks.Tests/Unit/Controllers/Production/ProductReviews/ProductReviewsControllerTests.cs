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
    public class ProductReviewsControllerTests : ControllerTests
    {
        private ProductReviewsController controller;
        private IProductReviewValidator validator;
        private IProductReviewService service;
        private ProductReviewView review;

        public ProductReviewsControllerTests()
        {
            validator = Substitute.For<IProductReviewValidator>();
            service = Substitute.For<IProductReviewService>();

            review = ObjectsFactory.CreateProductReviewView();

            controller = Substitute.ForPartsOf<ProductReviewsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsReviewViews()
        {
            service.GetViews().Returns(Array.Empty<ProductReviewView>().AsQueryable());

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
            validator.CanCreate(review).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(review)).Model;
            Object expected = review;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Review()
        {
            validator.CanCreate(review).Returns(true);

            controller.Create(review);

            service.Received().Create(review);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(review).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(review);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<ProductReviewView>(review.Id).Returns(review);

            Object expected = NotEmptyView(controller, review);
            Object actual = controller.Details(review.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<ProductReviewView>(review.Id).Returns(review);

            Object expected = NotEmptyView(controller, review);
            Object actual = controller.Edit(review.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(review).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(review)).Model;
            Object expected = review;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Review()
        {
            validator.CanEdit(review).Returns(true);

            controller.Edit(review);

            service.Received().Edit(review);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(review).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(review);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<ProductReviewView>(review.Id).Returns(review);

            Object expected = NotEmptyView(controller, review);
            Object actual = controller.Delete(review.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesReview()
        {
            controller.DeleteConfirmed(review.Id);

            service.Received().Delete(review.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(review.Id);

            Assert.Same(expected, actual);
        }
    }
}
