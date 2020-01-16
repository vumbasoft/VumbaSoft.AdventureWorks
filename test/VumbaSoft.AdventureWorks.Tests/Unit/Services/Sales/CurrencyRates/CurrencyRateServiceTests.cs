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
    public class CurrencyRateServiceTests : IDisposable
    {
        private CurrencyRateService service;
        private TestingContext context;
        private CurrencyRate rate;

        public CurrencyRateServiceTests()
        {
            context = new TestingContext();
            service = new CurrencyRateService(new UnitOfWork(new TestingContext(context)));

            context.Set<CurrencyRate>().Add(rate = ObjectsFactory.CreateCurrencyRate());
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
            CurrencyRateView actual = service.Get<CurrencyRateView>(rate.Id)!;
            CurrencyRateView expected = Mapper.Map<CurrencyRateView>(rate);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsRateViews()
        {
            CurrencyRateView[] actual = service.GetViews().ToArray();
            CurrencyRateView[] expected = context
                .Set<CurrencyRate>()
                .ProjectTo<CurrencyRateView>()
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
        public void Create_Rate()
        {
            CurrencyRateView view = ObjectsFactory.CreateCurrencyRateView(2);

            service.Create(view);

            CurrencyRate actual = context.Set<CurrencyRate>().AsNoTracking().Single(model => model.Id != rate.Id);
            CurrencyRateView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Rate()
        {
            CurrencyRateView view = ObjectsFactory.CreateCurrencyRateView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            CurrencyRate actual = context.Set<CurrencyRate>().AsNoTracking().Single();
            CurrencyRate expected = rate;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Rate()
        {
            service.Delete(rate.Id);

            Assert.Empty(context.Set<CurrencyRate>());
        }
    }
}
