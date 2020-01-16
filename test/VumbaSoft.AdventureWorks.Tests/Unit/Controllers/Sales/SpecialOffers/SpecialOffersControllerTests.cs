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
    public class SpecialOffersControllerTests : ControllerTests
    {
        private SpecialOffersController controller;
        private ISpecialOfferValidator validator;
        private ISpecialOfferService service;
        private SpecialOfferView offer;

        public SpecialOffersControllerTests()
        {
            validator = Substitute.For<ISpecialOfferValidator>();
            service = Substitute.For<ISpecialOfferService>();

            offer = ObjectsFactory.CreateSpecialOfferView();

            controller = Substitute.ForPartsOf<SpecialOffersController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsOfferViews()
        {
            service.GetViews().Returns(Array.Empty<SpecialOfferView>().AsQueryable());

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
            validator.CanCreate(offer).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(offer)).Model;
            Object expected = offer;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Offer()
        {
            validator.CanCreate(offer).Returns(true);

            controller.Create(offer);

            service.Received().Create(offer);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(offer).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(offer);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<SpecialOfferView>(offer.Id).Returns(offer);

            Object expected = NotEmptyView(controller, offer);
            Object actual = controller.Details(offer.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<SpecialOfferView>(offer.Id).Returns(offer);

            Object expected = NotEmptyView(controller, offer);
            Object actual = controller.Edit(offer.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(offer).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(offer)).Model;
            Object expected = offer;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Offer()
        {
            validator.CanEdit(offer).Returns(true);

            controller.Edit(offer);

            service.Received().Edit(offer);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(offer).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(offer);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<SpecialOfferView>(offer.Id).Returns(offer);

            Object expected = NotEmptyView(controller, offer);
            Object actual = controller.Delete(offer.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesOffer()
        {
            controller.DeleteConfirmed(offer.Id);

            service.Received().Delete(offer.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(offer.Id);

            Assert.Same(expected, actual);
        }
    }
}
