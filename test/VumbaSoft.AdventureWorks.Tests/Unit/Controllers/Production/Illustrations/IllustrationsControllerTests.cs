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
    public class IllustrationsControllerTests : ControllerTests
    {
        private IllustrationsController controller;
        private IIllustrationValidator validator;
        private IIllustrationService service;
        private IllustrationView illustration;

        public IllustrationsControllerTests()
        {
            validator = Substitute.For<IIllustrationValidator>();
            service = Substitute.For<IIllustrationService>();

            illustration = ObjectsFactory.CreateIllustrationView();

            controller = Substitute.ForPartsOf<IllustrationsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsIllustrationViews()
        {
            service.GetViews().Returns(Array.Empty<IllustrationView>().AsQueryable());

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
            validator.CanCreate(illustration).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(illustration)).Model;
            Object expected = illustration;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Illustration()
        {
            validator.CanCreate(illustration).Returns(true);

            controller.Create(illustration);

            service.Received().Create(illustration);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(illustration).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(illustration);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<IllustrationView>(illustration.Id).Returns(illustration);

            Object expected = NotEmptyView(controller, illustration);
            Object actual = controller.Details(illustration.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<IllustrationView>(illustration.Id).Returns(illustration);

            Object expected = NotEmptyView(controller, illustration);
            Object actual = controller.Edit(illustration.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(illustration).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(illustration)).Model;
            Object expected = illustration;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Illustration()
        {
            validator.CanEdit(illustration).Returns(true);

            controller.Edit(illustration);

            service.Received().Edit(illustration);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(illustration).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(illustration);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<IllustrationView>(illustration.Id).Returns(illustration);

            Object expected = NotEmptyView(controller, illustration);
            Object actual = controller.Delete(illustration.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesIllustration()
        {
            controller.DeleteConfirmed(illustration.Id);

            service.Received().Delete(illustration.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(illustration.Id);

            Assert.Same(expected, actual);
        }
    }
}
