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
    public class EmployeesControllerTests : ControllerTests
    {
        private EmployeesController controller;
        private IEmployeeValidator validator;
        private IEmployeeService service;
        private EmployeeView employee;

        public EmployeesControllerTests()
        {
            validator = Substitute.For<IEmployeeValidator>();
            service = Substitute.For<IEmployeeService>();

            employee = ObjectsFactory.CreateEmployeeView();

            controller = Substitute.ForPartsOf<EmployeesController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsEmployeeViews()
        {
            service.GetViews().Returns(Array.Empty<EmployeeView>().AsQueryable());

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
            validator.CanCreate(employee).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(employee)).Model;
            Object expected = employee;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Employee()
        {
            validator.CanCreate(employee).Returns(true);

            controller.Create(employee);

            service.Received().Create(employee);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(employee).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(employee);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<EmployeeView>(employee.Id).Returns(employee);

            Object expected = NotEmptyView(controller, employee);
            Object actual = controller.Details(employee.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<EmployeeView>(employee.Id).Returns(employee);

            Object expected = NotEmptyView(controller, employee);
            Object actual = controller.Edit(employee.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(employee).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(employee)).Model;
            Object expected = employee;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Employee()
        {
            validator.CanEdit(employee).Returns(true);

            controller.Edit(employee);

            service.Received().Edit(employee);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(employee).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(employee);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<EmployeeView>(employee.Id).Returns(employee);

            Object expected = NotEmptyView(controller, employee);
            Object actual = controller.Delete(employee.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesEmployee()
        {
            controller.DeleteConfirmed(employee.Id);

            service.Received().Delete(employee.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(employee.Id);

            Assert.Same(expected, actual);
        }
    }
}
