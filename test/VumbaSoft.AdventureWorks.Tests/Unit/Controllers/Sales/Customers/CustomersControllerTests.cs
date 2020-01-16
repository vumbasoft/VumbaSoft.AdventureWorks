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
    public class CustomersControllerTests : ControllerTests
    {
        private CustomersController controller;
        private ICustomerValidator validator;
        private ICustomerService service;
        private CustomerView customer;

        public CustomersControllerTests()
        {
            validator = Substitute.For<ICustomerValidator>();
            service = Substitute.For<ICustomerService>();

            customer = ObjectsFactory.CreateCustomerView();

            controller = Substitute.ForPartsOf<CustomersController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsCustomerViews()
        {
            service.GetViews().Returns(Array.Empty<CustomerView>().AsQueryable());

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
            validator.CanCreate(customer).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(customer)).Model;
            Object expected = customer;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Customer()
        {
            validator.CanCreate(customer).Returns(true);

            controller.Create(customer);

            service.Received().Create(customer);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(customer).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(customer);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<CustomerView>(customer.Id).Returns(customer);

            Object expected = NotEmptyView(controller, customer);
            Object actual = controller.Details(customer.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<CustomerView>(customer.Id).Returns(customer);

            Object expected = NotEmptyView(controller, customer);
            Object actual = controller.Edit(customer.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(customer).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(customer)).Model;
            Object expected = customer;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Customer()
        {
            validator.CanEdit(customer).Returns(true);

            controller.Edit(customer);

            service.Received().Edit(customer);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(customer).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(customer);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<CustomerView>(customer.Id).Returns(customer);

            Object expected = NotEmptyView(controller, customer);
            Object actual = controller.Delete(customer.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesCustomer()
        {
            controller.DeleteConfirmed(customer.Id);

            service.Received().Delete(customer.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(customer.Id);

            Assert.Same(expected, actual);
        }
    }
}
