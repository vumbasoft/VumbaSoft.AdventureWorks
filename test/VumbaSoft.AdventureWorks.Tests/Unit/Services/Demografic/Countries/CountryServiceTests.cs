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
    public class CountryServiceTests : IDisposable
    {
        private CountryService service;
        private TestingContext context;
        private Country country;

        public CountryServiceTests()
        {
            context = new TestingContext();
            service = new CountryService(new UnitOfWork(new TestingContext(context)));

            context.Set<Country>().Add(country = ObjectsFactory.CreateCountry());
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
            CountryView actual = service.Get<CountryView>(country.Id)!;
            CountryView expected = Mapper.Map<CountryView>(country);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsCountryViews()
        {
            CountryView[] actual = service.GetViews().ToArray();
            CountryView[] expected = context
                .Set<Country>()
                .ProjectTo<CountryView>()
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
        public void Create_Country()
        {
            CountryView view = ObjectsFactory.CreateCountryView(2);

            service.Create(view);

            Country actual = context.Set<Country>().AsNoTracking().Single(model => model.Id != country.Id);
            CountryView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Country()
        {
            CountryView view = ObjectsFactory.CreateCountryView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            Country actual = context.Set<Country>().AsNoTracking().Single();
            Country expected = country;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Country()
        {
            service.Delete(country.Id);

            Assert.Empty(context.Set<Country>());
        }
    }
}
