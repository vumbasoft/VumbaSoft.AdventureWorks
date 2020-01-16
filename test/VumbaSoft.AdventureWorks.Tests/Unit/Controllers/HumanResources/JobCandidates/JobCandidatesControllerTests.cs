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
    public class JobCandidatesControllerTests : ControllerTests
    {
        private JobCandidatesController controller;
        private IJobCandidateValidator validator;
        private IJobCandidateService service;
        private JobCandidateView candidate;

        public JobCandidatesControllerTests()
        {
            validator = Substitute.For<IJobCandidateValidator>();
            service = Substitute.For<IJobCandidateService>();

            candidate = ObjectsFactory.CreateJobCandidateView();

            controller = Substitute.ForPartsOf<JobCandidatesController>(validator, service);
            controller.ControllerContext.RouteData = new RouteData();
        }
        public override void Dispose()
        {
            controller.Dispose();
            validator.Dispose();
            service.Dispose();
        }

        [Fact]
        public void Index_ReturnsCandidateViews()
        {
            service.GetViews().Returns(Array.Empty<JobCandidateView>().AsQueryable());

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
            validator.CanCreate(candidate).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Create(candidate)).Model;
            Object expected = candidate;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Candidate()
        {
            validator.CanCreate(candidate).Returns(true);

            controller.Create(candidate);

            service.Received().Create(candidate);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(candidate).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Create(candidate);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<JobCandidateView>(candidate.Id).Returns(candidate);

            Object expected = NotEmptyView(controller, candidate);
            Object actual = controller.Details(candidate.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<JobCandidateView>(candidate.Id).Returns(candidate);

            Object expected = NotEmptyView(controller, candidate);
            Object actual = controller.Edit(candidate.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(candidate).Returns(false);

            Object actual = Assert.IsType<ViewResult>(controller.Edit(candidate)).Model;
            Object expected = candidate;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Candidate()
        {
            validator.CanEdit(candidate).Returns(true);

            controller.Edit(candidate);

            service.Received().Edit(candidate);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(candidate).Returns(true);

            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.Edit(candidate);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<JobCandidateView>(candidate.Id).Returns(candidate);

            Object expected = NotEmptyView(controller, candidate);
            Object actual = controller.Delete(candidate.Id);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void DeleteConfirmed_DeletesCandidate()
        {
            controller.DeleteConfirmed(candidate.Id);

            service.Received().Delete(candidate.Id);
        }

        [Fact]
        public void Delete_RedirectsToIndex()
        {
            Object expected = RedirectToAction(controller, "Index");
            Object actual = controller.DeleteConfirmed(candidate.Id);

            Assert.Same(expected, actual);
        }
    }
}
