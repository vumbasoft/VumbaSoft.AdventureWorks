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
    public class CountryRegionServiceTests : IDisposable
    {
        private CountryRegionService service;
        private TestingContext context;
        private CountryRegion region;

        public CountryRegionServiceTests()
        {
            context = new TestingContext();
            service = new CountryRegionService(new UnitOfWork(new TestingContext(context)));

            context.Set<CountryRegion>().Add(region = ObjectsFactory.CreateCountryRegion());
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
            CountryRegionView actual = service.Get<CountryRegionView>(region.Id)!;
            CountryRegionView expected = Mapper.Map<CountryRegionView>(region);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsRegionViews()
        {
            CountryRegionView[] actual = service.GetViews().ToArray();
            CountryRegionView[] expected = context
                .Set<CountryRegion>()
                .ProjectTo<CountryRegionView>()
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
            CountryRegionView view = ObjectsFactory.CreateCountryRegionView(2);

            service.Create(view);

            CountryRegion actual = context.Set<CountryRegion>().AsNoTracking().Single(model => model.Id != region.Id);
            CountryRegionView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Region()
        {
            CountryRegionView view = ObjectsFactory.CreateCountryRegionView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            CountryRegion actual = context.Set<CountryRegion>().AsNoTracking().Single();
            CountryRegion expected = region;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Region()
        {
            service.Delete(region.Id);

            Assert.Empty(context.Set<CountryRegion>());
        }
    }
}
