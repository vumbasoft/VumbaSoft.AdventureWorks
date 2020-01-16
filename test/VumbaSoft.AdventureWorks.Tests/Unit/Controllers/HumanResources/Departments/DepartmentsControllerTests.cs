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
    public class DepartmentsControllerTests : ControllerTests
    {
        private DepartmentsController controller;
        private IDepartmentValidator validator;
        private IDepartmentService service;
        private DepartmentView department;

        public DepartmentsControllerTests()
        {
            validator = Substitute.For<IDepartmentValidator>();
            service = Substitute.For<IDepartmentService>();

            department = ObjectsFactory.CreateDepartmentView();

            controller = Substitute.ForPartsOf<DepartmentsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsDepartmentViews()
        {
            service.GetViews().Returns(Array.Empty<DepartmentView>().AsQueryable());

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
            validator.CanCreate(department).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(department)).Model;
            Object expected = department;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Department()
        {
            validator.CanCreate(department).Returns(true);

            controller.Create(department);

            service.Received().Create(department);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(department).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(department);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<DepartmentView>(department.Id).Returns(department);

            Object expected = NotEmptyView(controller, department);
            Object actual = controller.Details(department.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<DepartmentView>(department.Id).Returns(department);

            Object expected = NotEmptyView(controller, department);
            Object actual = controller.Edit(department.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(department).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(department)).Model;
            Object expected = department;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Department()
        {
            validator.CanEdit(department).Returns(true);

            controller.Edit(department);

            service.Received().Edit(department);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(department).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(department);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<DepartmentView>(department.Id).Returns(department);

            Object expected = NotEmptyView(controller, department);
            Object actual = controller.Delete(department.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesDepartment()
        {
            controller.DeleteConfirmed(department.Id);

            service.Received().Delete(department.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(department.Id);

            Assert.Same(expected, actual);
        }
    }
}
