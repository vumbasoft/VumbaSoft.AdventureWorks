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
    public class EmployeePayHistoriesControllerTests : ControllerTests
    {
        private EmployeePayHistoriesController controller;
        private IEmployeepayhistoryValidator validator;
        private IEmployeepayhistoryService service;
        private EmployeePayHistoryView employeepayhistory;

        public EmployeePayHistoriesControllerTests()
        {
            validator = Substitute.For<IEmployeepayhistoryValidator>();
            service = Substitute.For<IEmployeepayhistoryService>();

            employeepayhistory = ObjectsFactory.CreateEmployeepayhistoryView();

            controller = Substitute.ForPartsOf<EmployeePayHistoriesController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsEmployeepayhistoryViews()
        {
            service.GetViews().Returns(Array.Empty<EmployeePayHistoryView>().AsQueryable());

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
            validator.CanCreate(employeepayhistory).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(employeepayhistory)).Model;
            Object expected = employeepayhistory;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Employeepayhistory()
        {
            validator.CanCreate(employeepayhistory).Returns(true);

            controller.Create(employeepayhistory);

            service.Received().Create(employeepayhistory);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(employeepayhistory).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(employeepayhistory);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<EmployeePayHistoryView>(employeepayhistory.Id).Returns(employeepayhistory);

            Object expected = NotEmptyView(controller, employeepayhistory);
            Object actual = controller.Details(employeepayhistory.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<EmployeePayHistoryView>(employeepayhistory.Id).Returns(employeepayhistory);

            Object expected = NotEmptyView(controller, employeepayhistory);
            Object actual = controller.Edit(employeepayhistory.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(employeepayhistory).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(employeepayhistory)).Model;
            Object expected = employeepayhistory;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Employeepayhistory()
        {
            validator.CanEdit(employeepayhistory).Returns(true);

            controller.Edit(employeepayhistory);

            service.Received().Edit(employeepayhistory);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(employeepayhistory).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(employeepayhistory);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<EmployeePayHistoryView>(employeepayhistory.Id).Returns(employeepayhistory);

            Object expected = NotEmptyView(controller, employeepayhistory);
            Object actual = controller.Delete(employeepayhistory.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesEmployeepayhistory()
        {
            controller.DeleteConfirmed(employeepayhistory.Id);

            service.Received().Delete(employeepayhistory.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(employeepayhistory.Id);

            Assert.Same(expected, actual);
        }
    }
}
