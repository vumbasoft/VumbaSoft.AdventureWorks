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
    public class LocationServiceTests : IDisposable
    {
        private LocationService service;
        private TestingContext context;
        private Location location;

        public LocationServiceTests()
        {
            context = new TestingContext();
            service = new LocationService(new UnitOfWork(new TestingContext(context)));

            context.Set<Location>().Add(location = ObjectsFactory.CreateLocation());
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
            LocationView actual = service.Get<LocationView>(location.Id)!;
            LocationView expected = Mapper.Map<LocationView>(location);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsLocationViews()
        {
            LocationView[] actual = service.GetViews().ToArray();
            LocationView[] expected = context
                .Set<Location>()
                .ProjectTo<LocationView>()
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
        public void Create_Location()
        {
            LocationView view = ObjectsFactory.CreateLocationView(2);

            service.Create(view);

            Location actual = context.Set<Location>().AsNoTracking().Single(model => model.Id != location.Id);
            LocationView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Location()
        {
            LocationView view = ObjectsFactory.CreateLocationView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            Location actual = context.Set<Location>().AsNoTracking().Single();
            Location expected = location;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Location()
        {
            service.Delete(location.Id);

            Assert.Empty(context.Set<Location>());
        }
    }
}
