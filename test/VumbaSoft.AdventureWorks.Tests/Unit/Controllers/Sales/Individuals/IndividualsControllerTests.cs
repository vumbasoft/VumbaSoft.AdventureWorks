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
    public class IndividualsControllerTests : ControllerTests
    {
        private IndividualsController controller;
        private IIndividualValidator validator;
        private IIndividualService service;
        private IndividualView individual;

        public IndividualsControllerTests()
        {
            validator = Substitute.For<IIndividualValidator>();
            service = Substitute.For<IIndividualService>();

            individual = ObjectsFactory.CreateIndividualView();

            controller = Substitute.ForPartsOf<IndividualsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsIndividualViews()
        {
            service.GetViews().Returns(Array.Empty<IndividualView>().AsQueryable());

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
            validator.CanCreate(individual).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(individual)).Model;
            Object expected = individual;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Individual()
        {
            validator.CanCreate(individual).Returns(true);

            controller.Create(individual);

            service.Received().Create(individual);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(individual).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(individual);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<IndividualView>(individual.Id).Returns(individual);

            Object expected = NotEmptyView(controller, individual);
            Object actual = controller.Details(individual.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<IndividualView>(individual.Id).Returns(individual);

            Object expected = NotEmptyView(controller, individual);
            Object actual = controller.Edit(individual.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(individual).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(individual)).Model;
            Object expected = individual;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Individual()
        {
            validator.CanEdit(individual).Returns(true);

            controller.Edit(individual);

            service.Received().Edit(individual);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(individual).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(individual);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<IndividualView>(individual.Id).Returns(individual);

            Object expected = NotEmptyView(controller, individual);
            Object actual = controller.Delete(individual.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesIndividual()
        {
            controller.DeleteConfirmed(individual.Id);

            service.Received().Delete(individual.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(individual.Id);

            Assert.Same(expected, actual);
        }
    }
}
