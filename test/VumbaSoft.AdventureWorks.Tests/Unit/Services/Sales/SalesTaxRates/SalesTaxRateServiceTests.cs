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
    public class SalesTaxRateServiceTests : IDisposable
    {
        private SalesTaxRateService service;
        private TestingContext context;
        private SalesTaxRate rate;

        public SalesTaxRateServiceTests()
        {
            context = new TestingContext();
            service = new SalesTaxRateService(new UnitOfWork(new TestingContext(context)));

            context.Set<SalesTaxRate>().Add(rate = ObjectsFactory.CreateSalesTaxRate());
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
            SalesTaxRateView actual = service.Get<SalesTaxRateView>(rate.Id)!;
            SalesTaxRateView expected = Mapper.Map<SalesTaxRateView>(rate);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsRateViews()
        {
            SalesTaxRateView[] actual = service.GetViews().ToArray();
            SalesTaxRateView[] expected = context
                .Set<SalesTaxRate>()
                .ProjectTo<SalesTaxRateView>()
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
            SalesTaxRateView view = ObjectsFactory.CreateSalesTaxRateView(2);

            service.Create(view);

            SalesTaxRate actual = context.Set<SalesTaxRate>().AsNoTracking().Single(model => model.Id != rate.Id);
            SalesTaxRateView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Rate()
        {
            SalesTaxRateView view = ObjectsFactory.CreateSalesTaxRateView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            SalesTaxRate actual = context.Set<SalesTaxRate>().AsNoTracking().Single();
            SalesTaxRate expected = rate;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Rate()
        {
            service.Delete(rate.Id);

            Assert.Empty(context.Set<SalesTaxRate>());
        }
    }
}
