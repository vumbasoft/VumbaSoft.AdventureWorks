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

namespace VumbaSoft.AdventureWorks.Controllers.HumanResources.Tests
{
    public class ShiftsControllerTests : ControllerTests
    {
        private ShiftsController controller;
        private IShiftValidator validator;
        private IShiftService service;
        private ShiftView shift;

        public ShiftsControllerTests()
        {
            validator = Substitute.For<IShiftValidator>();
            service = Substitute.For<IShiftService>();

            shift = ObjectsFactory.CreateShiftView();

            controller = Substitute.ForPartsOf<ShiftsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsShiftViews()
        {
            service.GetViews().Returns(Array.Empty<ShiftView>().AsQueryable());

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
            validator.CanCreate(shift).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(shift)).Model;
            Object expected = shift;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Shift()
        {
            validator.CanCreate(shift).Returns(true);

            controller.Create(shift);

            service.Received().Create(shift);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(shift).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(shift);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<ShiftView>(shift.Id).Returns(shift);

            Object expected = NotEmptyView(controller, shift);
            Object actual = controller.Details(shift.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<ShiftView>(shift.Id).Returns(shift);

            Object expected = NotEmptyView(controller, shift);
            Object actual = controller.Edit(shift.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(shift).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(shift)).Model;
            Object expected = shift;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Shift()
        {
            validator.CanEdit(shift).Returns(true);

            controller.Edit(shift);

            service.Received().Edit(shift);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(shift).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(shift);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<ShiftView>(shift.Id).Returns(shift);

            Object expected = NotEmptyView(controller, shift);
            Object actual = controller.Delete(shift.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesShift()
        {
            controller.DeleteConfirmed(shift.Id);

            service.Received().Delete(shift.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(shift.Id);

            Assert.Same(expected, actual);
        }
    }
}
