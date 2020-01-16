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
    public class ContactCreditCardsControllerTests : ControllerTests
    {
        private ContactCreditCardsController controller;
        private IContactCreditCardValidator validator;
        private IContactCreditCardService service;
        private ContactCreditCardView card;

        public ContactCreditCardsControllerTests()
        {
            validator = Substitute.For<IContactCreditCardValidator>();
            service = Substitute.For<IContactCreditCardService>();

            card = ObjectsFactory.CreateContactCreditCardView();

            controller = Substitute.ForPartsOf<ContactCreditCardsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsCardViews()
        {
            service.GetViews().Returns(Array.Empty<ContactCreditCardView>().AsQueryable());

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
            validator.CanCreate(card).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(card)).Model;
            Object expected = card;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Card()
        {
            validator.CanCreate(card).Returns(true);

            controller.Create(card);

            service.Received().Create(card);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(card).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(card);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<ContactCreditCardView>(card.Id).Returns(card);

            Object expected = NotEmptyView(controller, card);
            Object actual = controller.Details(card.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<ContactCreditCardView>(card.Id).Returns(card);

            Object expected = NotEmptyView(controller, card);
            Object actual = controller.Edit(card.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(card).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(card)).Model;
            Object expected = card;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Card()
        {
            validator.CanEdit(card).Returns(true);

            controller.Edit(card);

            service.Received().Edit(card);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(card).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(card);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<ContactCreditCardView>(card.Id).Returns(card);

            Object expected = NotEmptyView(controller, card);
            Object actual = controller.Delete(card.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesCard()
        {
            controller.DeleteConfirmed(card.Id);

            service.Received().Delete(card.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(card.Id);

            Assert.Same(expected, actual);
        }
    }
}
