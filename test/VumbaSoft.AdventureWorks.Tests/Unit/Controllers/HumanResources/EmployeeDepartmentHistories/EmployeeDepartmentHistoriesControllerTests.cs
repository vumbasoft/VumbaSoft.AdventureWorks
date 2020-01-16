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
    public class EmployeeDepartmentHistoriesControllerTests : ControllerTests
    {
        private EmployeeDepartmentHistoriesController controller;
        private IEmployeedepartmenthistoryValidator validator;
        private IEmployeedepartmenthistoryService service;
        private EmployeeDepartmentHistoryView employeedepartmenthistory;

        public EmployeeDepartmentHistoriesControllerTests()
        {
            validator = Substitute.For<IEmployeedepartmenthistoryValidator>();
            service = Substitute.For<IEmployeedepartmenthistoryService>();

            employeedepartmenthistory = ObjectsFactory.CreateEmployeedepartmenthistoryView();

            controller = Substitute.ForPartsOf<EmployeeDepartmentHistoriesController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsEmployeedepartmenthistoryViews()
        {
            service.GetViews().Returns(Array.Empty<EmployeeDepartmentHistoryView>().AsQueryable());

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
            validator.CanCreate(employeedepartmenthistory).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(employeedepartmenthistory)).Model;
            Object expected = employeedepartmenthistory;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Employeedepartmenthistory()
        {
            validator.CanCreate(employeedepartmenthistory).Returns(true);

            controller.Create(employeedepartmenthistory);

            service.Received().Create(employeedepartmenthistory);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(employeedepartmenthistory).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(employeedepartmenthistory);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<EmployeeDepartmentHistoryView>(employeedepartmenthistory.Id).Returns(employeedepartmenthistory);

            Object expected = NotEmptyView(controller, employeedepartmenthistory);
            Object actual = controller.Details(employeedepartmenthistory.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<EmployeeDepartmentHistoryView>(employeedepartmenthistory.Id).Returns(employeedepartmenthistory);

            Object expected = NotEmptyView(controller, employeedepartmenthistory);
            Object actual = controller.Edit(employeedepartmenthistory.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(employeedepartmenthistory).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(employeedepartmenthistory)).Model;
            Object expected = employeedepartmenthistory;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Employeedepartmenthistory()
        {
            validator.CanEdit(employeedepartmenthistory).Returns(true);

            controller.Edit(employeedepartmenthistory);

            service.Received().Edit(employeedepartmenthistory);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(employeedepartmenthistory).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(employeedepartmenthistory);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<EmployeeDepartmentHistoryView>(employeedepartmenthistory.Id).Returns(employeedepartmenthistory);

            Object expected = NotEmptyView(controller, employeedepartmenthistory);
            Object actual = controller.Delete(employeedepartmenthistory.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesEmployeedepartmenthistory()
        {
            controller.DeleteConfirmed(employeedepartmenthistory.Id);

            service.Received().Delete(employeedepartmenthistory.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(employeedepartmenthistory.Id);

            Assert.Same(expected, actual);
        }
    }
}
