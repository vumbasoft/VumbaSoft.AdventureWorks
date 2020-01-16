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
    public class ProductListPriceHistoryServiceTests : IDisposable
    {
        private ProductListPriceHistoryService service;
        private TestingContext context;
        private ProductListPriceHistory history;

        public ProductListPriceHistoryServiceTests()
        {
            context = new TestingContext();
            service = new ProductListPriceHistoryService(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductListPriceHistory>().Add(history = ObjectsFactory.CreateProductListPriceHistory());
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
            ProductListPriceHistoryView actual = service.Get<ProductListPriceHistoryView>(history.Id)!;
            ProductListPriceHistoryView expected = Mapper.Map<ProductListPriceHistoryView>(history);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsHistoryViews()
        {
            ProductListPriceHistoryView[] actual = service.GetViews().ToArray();
            ProductListPriceHistoryView[] expected = context
                .Set<ProductListPriceHistory>()
                .ProjectTo<ProductListPriceHistoryView>()
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
        public void Create_History()
        {
            ProductListPriceHistoryView view = ObjectsFactory.CreateProductListPriceHistoryView(2);

            service.Create(view);

            ProductListPriceHistory actual = context.Set<ProductListPriceHistory>().AsNoTracking().Single(model => model.Id != history.Id);
            ProductListPriceHistoryView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_History()
        {
            ProductListPriceHistoryView view = ObjectsFactory.CreateProductListPriceHistoryView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            ProductListPriceHistory actual = context.Set<ProductListPriceHistory>().AsNoTracking().Single();
            ProductListPriceHistory expected = history;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_History()
        {
            service.Delete(history.Id);

            Assert.Empty(context.Set<ProductListPriceHistory>());
        }
    }
}
