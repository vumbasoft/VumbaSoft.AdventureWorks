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
    public class ContinentServiceTests : IDisposable
    {
        private ContinentService service;
        private TestingContext context;
        private Continent continent;

        public ContinentServiceTests()
        {
            context = new TestingContext();
            service = new ContinentService(new UnitOfWork(new TestingContext(context)));

            context.Set<Continent>().Add(continent = ObjectsFactory.CreateContinent());
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
            ContinentView actual = service.Get<ContinentView>(continent.Id)!;
            ContinentView expected = Mapper.Map<ContinentView>(continent);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsContinentViews()
        {
            ContinentView[] actual = service.GetViews().ToArray();
            ContinentView[] expected = context
                .Set<Continent>()
                .ProjectTo<ContinentView>()
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
        public void Create_Continent()
        {
            ContinentView view = ObjectsFactory.CreateContinentView(2);

            service.Create(view);

            Continent actual = context.Set<Continent>().AsNoTracking().Single(model => model.Id != continent.Id);
            ContinentView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Continent()
        {
            ContinentView view = ObjectsFactory.CreateContinentView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            Continent actual = context.Set<Continent>().AsNoTracking().Single();
            Continent expected = continent;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Continent()
        {
            service.Delete(continent.Id);

            Assert.Empty(context.Set<Continent>());
        }
    }
}
