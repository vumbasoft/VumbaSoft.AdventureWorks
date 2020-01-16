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

namespace VumbaSoft.AdventureWorks.Controllers.Person.Tests
{
    public class StateProvincesControllerTests : ControllerTests
    {
        private StateProvincesController controller;
        private IStateProvinceValidator validator;
        private IStateProvinceService service;
        private StateProvinceView province;

        public StateProvincesControllerTests()
        {
            validator = Substitute.For<IStateProvinceValidator>();
            service = Substitute.For<IStateProvinceService>();

            province = ObjectsFactory.CreateStateProvinceView();

            controller = Substitute.ForPartsOf<StateProvincesController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsProvinceViews()
        {
            service.GetViews().Returns(Array.Empty<StateProvinceView>().AsQueryable());

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
            validator.CanCreate(province).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(province)).Model;
            Object expected = province;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Province()
        {
            validator.CanCreate(province).Returns(true);

            controller.Create(province);

            service.Received().Create(province);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(province).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(province);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<StateProvinceView>(province.Id).Returns(province);

            Object expected = NotEmptyView(controller, province);
            Object actual = controller.Details(province.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<StateProvinceView>(province.Id).Returns(province);

            Object expected = NotEmptyView(controller, province);
            Object actual = controller.Edit(province.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(province).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(province)).Model;
            Object expected = province;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Province()
        {
            validator.CanEdit(province).Returns(true);

            controller.Edit(province);

            service.Received().Edit(province);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(province).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(province);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<StateProvinceView>(province.Id).Returns(province);

            Object expected = NotEmptyView(controller, province);
            Object actual = controller.Delete(province.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesProvince()
        {
            controller.DeleteConfirmed(province.Id);

            service.Received().Delete(province.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(province.Id);

            Assert.Same(expected, actual);
        }
    }
}
