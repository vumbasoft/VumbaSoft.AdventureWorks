using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class JobCandidateValidatorTests : IDisposable
    {
        private JobCandidateValidator validator;
        private TestingContext context;
        private JobCandidate candidate;

        public JobCandidateValidatorTests()
        {
            context = new TestingContext();
            validator = new JobCandidateValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<JobCandidate>().Add(candidate = ObjectsFactory.CreateJobCandidate());
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
            validator.Dispose();
        }

        [Fact]
        public void CanCreate_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanCreate(ObjectsFactory.CreateJobCandidateView(2)));
        }

        [Fact]
        public void CanCreate_ValidCandidate()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateJobCandidateView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateJobCandidateView()));
        }

        [Fact]
        public void CanEdit_ValidCandidate()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateJobCandidateView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
