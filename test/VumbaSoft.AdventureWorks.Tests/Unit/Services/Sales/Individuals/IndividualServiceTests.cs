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
    public class IndividualServiceTests : IDisposable
    {
        private IndividualService service;
        private TestingContext context;
        private Individual individual;

        public IndividualServiceTests()
        {
            context = new TestingContext();
            service = new IndividualService(new UnitOfWork(new TestingContext(context)));

            context.Set<Individual>().Add(individual = ObjectsFactory.CreateIndividual());
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
            IndividualView actual = service.Get<IndividualView>(individual.Id)!;
            IndividualView expected = Mapper.Map<IndividualView>(individual);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsIndividualViews()
        {
            IndividualView[] actual = service.GetViews().ToArray();
            IndividualView[] expected = context
                .Set<Individual>()
                .ProjectTo<IndividualView>()
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
        public void Create_Individual()
        {
            IndividualView view = ObjectsFactory.CreateIndividualView(2);

            service.Create(view);

            Individual actual = context.Set<Individual>().AsNoTracking().Single(model => model.Id != individual.Id);
            IndividualView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Individual()
        {
            IndividualView view = ObjectsFactory.CreateIndividualView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            Individual actual = context.Set<Individual>().AsNoTracking().Single();
            Individual expected = individual;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Individual()
        {
            service.Delete(individual.Id);

            Assert.Empty(context.Set<Individual>());
        }
    }
}
