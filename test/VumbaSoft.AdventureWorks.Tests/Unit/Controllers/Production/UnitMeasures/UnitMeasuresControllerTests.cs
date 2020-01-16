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
    public class UnitMeasuresControllerTests : ControllerTests
    {
        private UnitMeasuresController controller;
        private IUnitMeasureValidator validator;
        private IUnitMeasureService service;
        private UnitMeasureView measure;

        public UnitMeasuresControllerTests()
        {
            validator = Substitute.For<IUnitMeasureValidator>();
            service = Substitute.For<IUnitMeasureService>();

            measure = ObjectsFactory.CreateUnitMeasureView();

            controller = Substitute.ForPartsOf<UnitMeasuresController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsMeasureViews()
        {
            service.GetViews().Returns(Array.Empty<UnitMeasureView>().AsQueryable());

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
            validator.CanCreate(measure).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(measure)).Model;
            Object expected = measure;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Measure()
        {
            validator.CanCreate(measure).Returns(true);

            controller.Create(measure);

            service.Received().Create(measure);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(measure).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(measure);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<UnitMeasureView>(measure.Id).Returns(measure);

            Object expected = NotEmptyView(controller, measure);
            Object actual = controller.Details(measure.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<UnitMeasureView>(measure.Id).Returns(measure);

            Object expected = NotEmptyView(controller, measure);
            Object actual = controller.Edit(measure.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(measure).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(measure)).Model;
            Object expected = measure;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Measure()
        {
            validator.CanEdit(measure).Returns(true);

            controller.Edit(measure);

            service.Received().Edit(measure);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(measure).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(measure);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<UnitMeasureView>(measure.Id).Returns(measure);

            Object expected = NotEmptyView(controller, measure);
            Object actual = controller.Delete(measure.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesMeasure()
        {
            controller.DeleteConfirmed(measure.Id);

            service.Received().Delete(measure.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(measure.Id);

            Assert.Same(expected, actual);
        }
    }
}
