using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using System.Linq;
using Xunit;

namespace VumbaSoft.AdventureWorks.Services.Tests
{
    public class JobCandidateServiceTests : IDisposable
    {
        private JobCandidateService service;
        private TestingContext context;
        private JobCandidate candidate;

        public JobCandidateServiceTests()
        {
            context = new TestingContext();
            service = new JobCandidateService(new UnitOfWork(new TestingContext(context)));

            context.Set<JobCandidate>().Add(candidate = ObjectsFactory.CreateJobCandidate());
            context.SaveChanges();
        }
        public void Dispose()
        {
            service.Dispose();
            context.Dispose();
        }

        [Fact]
        public void Get_ReturnsViewById()
        {
            JobCandidateView actual = service.Get<JobCandidateView>(candidate.Id)!;
            JobCandidateView expected = Mapper.Map<JobCandidateView>(candidate);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsCandidateViews()
        {
            JobCandidateView[] actual = service.GetViews().ToArray();
            JobCandidateView[] expected = context
                .Set<JobCandidate>()
                .ProjectTo<JobCandidateView>()
                .OrderByDescending(view => view.CreationDate)
                .ToArray();

            for (Int32 i = 0; i < expected.Length || i < actual.Length; i++)
            {
                Assert.Equal(expected[i].CreationDate, actual[i].CreationDate);
                Assert.Equal(expected[i].Id, actual[i].Id);
            }
            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Create_Candidate()
        {
            JobCandidateView view = ObjectsFactory.CreateJobCandidateView(2);

            service.Create(view);

            JobCandidate actual = context.Set<JobCandidate>().AsNoTracking().Single(model => model.Id != candidate.Id);
            JobCandidateView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Candidate()
        {
            JobCandidateView view = ObjectsFactory.CreateJobCandidateView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            JobCandidate actual = context.Set<JobCandidate>().AsNoTracking().Single();
            JobCandidate expected = candidate;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Candidate()
        {
            service.Delete(candidate.Id);

            Assert.Empty(context.Set<JobCandidate>());
        }
    }
}
