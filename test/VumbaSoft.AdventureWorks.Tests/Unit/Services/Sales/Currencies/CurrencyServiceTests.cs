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
    public class CurrencyServiceTests : IDisposable
    {
        private CurrencyService service;
        private TestingContext context;
        private Currency currency;

        public CurrencyServiceTests()
        {
            context = new TestingContext();
            service = new CurrencyService(new UnitOfWork(new TestingContext(context)));

            context.Set<Currency>().Add(currency = ObjectsFactory.CreateCurrency());
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
            CurrencyView actual = service.Get<CurrencyView>(currency.Id)!;
            CurrencyView expected = Mapper.Map<CurrencyView>(currency);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsCurrencyViews()
        {
            CurrencyView[] actual = service.GetViews().ToArray();
            CurrencyView[] expected = context
                .Set<Currency>()
                .ProjectTo<CurrencyView>()
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
            CurrencyView view = ObjectsFactory.CreateCurrencyView(2);

            service.Create(view);

            Currency actual = context.Set<Currency>().AsNoTracking().Single(model => model.Id != currency.Id);
            CurrencyView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Currency()
        {
            CurrencyView view = ObjectsFactory.CreateCurrencyView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            Currency actual = context.Set<Currency>().AsNoTracking().Single();
            Currency expected = currency;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Currency()
        {
            service.Delete(currency.Id);

            Assert.Empty(context.Set<Currency>());
        }
    }
}
