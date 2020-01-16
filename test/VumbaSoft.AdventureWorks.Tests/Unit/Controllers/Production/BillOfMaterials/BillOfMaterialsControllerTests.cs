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
    public class BillOfMaterialsControllerTests : ControllerTests
    {
        private BillOfMaterialsController controller;
        private IBillOfMaterialValidator validator;
        private IBillOfMaterialService service;
        private BillOfMaterialView material;

        public BillOfMaterialsControllerTests()
        {
            validator = Substitute.For<IBillOfMaterialValidator>();
            service = Substitute.For<IBillOfMaterialService>();

            material = ObjectsFactory.CreateBillOfMaterialView();

            controller = Substitute.ForPartsOf<BillOfMaterialsController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsMaterialViews()
        {
            service.GetViews().Returns(Array.Empty<BillOfMaterialView>().AsQueryable());

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
            validator.CanCreate(material).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(material)).Model;
            Object expected = material;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Material()
        {
            validator.CanCreate(material).Returns(true);

            controller.Create(material);

            service.Received().Create(material);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(material).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(material);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<BillOfMaterialView>(material.Id).Returns(material);

            Object expected = NotEmptyView(controller, material);
            Object actual = controller.Details(material.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<BillOfMaterialView>(material.Id).Returns(material);

            Object expected = NotEmptyView(controller, material);
            Object actual = controller.Edit(material.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(material).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(material)).Model;
            Object expected = material;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Material()
        {
            validator.CanEdit(material).Returns(true);

            controller.Edit(material);

            service.Received().Edit(material);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(material).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(material);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<BillOfMaterialView>(material.Id).Returns(material);

            Object expected = NotEmptyView(controller, material);
            Object actual = controller.Delete(material.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesMaterial()
        {
            controller.DeleteConfirmed(material.Id);

            service.Received().Delete(material.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(material.Id);

            Assert.Same(expected, actual);
        }
    }
}
