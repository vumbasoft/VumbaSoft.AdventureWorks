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
    public class RegionServiceTests : IDisposable
    {
        private RegionService service;
        private TestingContext context;
        private Region region;

        public RegionServiceTests()
        {
            context = new TestingContext();
            service = new RegionService(new UnitOfWork(new TestingContext(context)));

            context.Set<Region>().Add(region = ObjectsFactory.CreateRegion());
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
            RegionView actual = service.Get<RegionView>(region.Id)!;
            RegionView expected = Mapper.Map<RegionView>(region);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsRegionViews()
        {
            RegionView[] actual = service.GetViews().ToArray();
            RegionView[] expected = context
                .Set<Region>()
                .ProjectTo<RegionView>()
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
            RegionView view = ObjectsFactory.CreateRegionView(2);

            service.Create(view);

            Region actual = context.Set<Region>().AsNoTracking().Single(model => model.Id != region.Id);
            RegionView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Region()
        {
            RegionView view = ObjectsFactory.CreateRegionView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            Region actual = context.Set<Region>().AsNoTracking().Single();
            Region expected = region;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Region()
        {
            service.Delete(region.Id);

            Assert.Empty(context.Set<Region>());
        }
    }
}
