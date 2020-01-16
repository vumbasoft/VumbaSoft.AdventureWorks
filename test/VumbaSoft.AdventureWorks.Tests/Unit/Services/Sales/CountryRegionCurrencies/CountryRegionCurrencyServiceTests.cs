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
    public class CountryRegionCurrencyServiceTests : IDisposable
    {
        private CountryRegionCurrencyService service;
        private TestingContext context;
        private CountryRegionCurrency currency;

        public CountryRegionCurrencyServiceTests()
        {
            context = new TestingContext();
            service = new CountryRegionCurrencyService(new UnitOfWork(new TestingContext(context)));

            context.Set<CountryRegionCurrency>().Add(currency = ObjectsFactory.CreateCountryRegionCurrency());
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
            CountryRegionCurrencyView actual = service.Get<CountryRegionCurrencyView>(currency.Id)!;
            CountryRegionCurrencyView expected = Mapper.Map<CountryRegionCurrencyView>(currency);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsCurrencyViews()
        {
            CountryRegionCurrencyView[] actual = service.GetViews().ToArray();
            CountryRegionCurrencyView[] expected = context
                .Set<CountryRegionCurrency>()
                .ProjectTo<CountryRegionCurrencyView>()
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
        public void Create_Currency()
        {
            CountryRegionCurrencyView view = ObjectsFactory.CreateCountryRegionCurrencyView(2);

            service.Create(view);

            CountryRegionCurrency actual = context.Set<CountryRegionCurrency>().AsNoTracking().Single(model => model.Id != currency.Id);
            CountryRegionCurrencyView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Currency()
        {
            CountryRegionCurrencyView view = ObjectsFactory.CreateCountryRegionCurrencyView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            CountryRegionCurrency actual = context.Set<CountryRegionCurrency>().AsNoTracking().Single();
            CountryRegionCurrency expected = currency;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Currency()
        {
            service.Delete(currency.Id);

            Assert.Empty(context.Set<CountryRegionCurrency>());
        }
    }
}
