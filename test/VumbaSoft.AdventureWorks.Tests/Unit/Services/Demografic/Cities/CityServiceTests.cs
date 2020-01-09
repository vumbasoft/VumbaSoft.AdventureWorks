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
    public class CityServiceTests : IDisposable
    {
        private CityService service;
        private TestingContext context;
        private City city;

        public CityServiceTests()
        {
            context = new TestingContext();
            service = new CityService(new UnitOfWork(new TestingContext(context)));

            context.Set<City>().Add(city = ObjectsFactory.CreateCity());
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
            CityView actual = service.Get<CityView>(city.Id)!;
            CityView expected = Mapper.Map<CityView>(city);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsCityViews()
        {
            CityView[] actual = service.GetViews().ToArray();
            CityView[] expected = context
                .Set<City>()
                .ProjectTo<CityView>()
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
        public void Create_City()
        {
            CityView view = ObjectsFactory.CreateCityView(2);

            service.Create(view);

            City actual = context.Set<City>().AsNoTracking().Single(model => model.Id != city.Id);
            CityView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_City()
        {
            CityView view = ObjectsFactory.CreateCityView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            City actual = context.Set<City>().AsNoTracking().Single();
            City expected = city;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_City()
        {
            service.Delete(city.Id);

            Assert.Empty(context.Set<City>());
        }
    }
}
