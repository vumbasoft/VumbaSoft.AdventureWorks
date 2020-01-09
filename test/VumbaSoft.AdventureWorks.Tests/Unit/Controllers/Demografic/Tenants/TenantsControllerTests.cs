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

namespace VumbaSoft.AdventureWorks.Controllers.Demografic.Tests
{
    public class TenantsControllerTests : ControllerTests
    {
        private TenantsController controller;
        private ITenantValidator validator;
        private ITenantService service;
        private TenantView tenant;

        public TenantsControllerTests()
        {
            validator = Substitute.For<ITenantValidator>();
            service = Substitute.For<ITenantService>();

            tenant = ObjectsFactory.CreateTenantView();

            controller = Substitute.ForPartsOf<TenantsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsTenantViews()
        {
            service.GetViews().Returns(Array.Empty<TenantView>().AsQueryable());

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
            validator.CanCreate(tenant).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(tenant)).Model;
            Object expected = tenant;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Tenant()
        {
            validator.CanCreate(tenant).Returns(true);

            controller.Create(tenant);

            service.Received().Create(tenant);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(tenant).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(tenant);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<TenantView>(tenant.Id).Returns(tenant);

            Object expected = NotEmptyView(controller, tenant);
            Object actual = controller.Details(tenant.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<TenantView>(tenant.Id).Returns(tenant);

            Object expected = NotEmptyView(controller, tenant);
            Object actual = controller.Edit(tenant.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(tenant).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(tenant)).Model;
            Object expected = tenant;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Tenant()
        {
            validator.CanEdit(tenant).Returns(true);

            controller.Edit(tenant);

            service.Received().Edit(tenant);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(tenant).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(tenant);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<TenantView>(tenant.Id).Returns(tenant);

            Object expected = NotEmptyView(controller, tenant);
            Object actual = controller.Delete(tenant.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesTenant()
        {
            controller.DeleteConfirmed(tenant.Id);

            service.Received().Delete(tenant.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(tenant.Id);

            Assert.Same(expected, actual);
        }
    }
}
