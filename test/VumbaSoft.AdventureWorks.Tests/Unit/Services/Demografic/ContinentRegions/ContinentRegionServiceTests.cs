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
    public class ContinentRegionServiceTests : IDisposable
    {
        private ContinentRegionService service;
        private TestingContext context;
        private ContinentRegion region;

        public ContinentRegionServiceTests()
        {
            context = new TestingContext();
            service = new ContinentRegionService(new UnitOfWork(new TestingContext(context)));

            context.Set<ContinentRegion>().Add(region = ObjectsFactory.CreateContinentRegion());
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
            ContinentRegionView actual = service.Get<ContinentRegionView>(region.Id)!;
            ContinentRegionView expected = Mapper.Map<ContinentRegionView>(region);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsRegionViews()
        {
            ContinentRegionView[] actual = service.GetViews().ToArray();
            ContinentRegionView[] expected = context
                .Set<ContinentRegion>()
                .ProjectTo<ContinentRegionView>()
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
        public void Create_Region()
        {
            ContinentRegionView view = ObjectsFactory.CreateContinentRegionView(2);

            service.Create(view);

            ContinentRegion actual = context.Set<ContinentRegion>().AsNoTracking().Single(model => model.Id != region.Id);
            ContinentRegionView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Region()
        {
            ContinentRegionView view = ObjectsFactory.CreateContinentRegionView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            ContinentRegion actual = context.Set<ContinentRegion>().AsNoTracking().Single();
            ContinentRegion expected = region;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Region()
        {
            service.Delete(region.Id);

            Assert.Empty(context.Set<ContinentRegion>());
        }
    }
}
