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
    public class ProductCostHistoryServiceTests : IDisposable
    {
        private ProductCostHistoryService service;
        private TestingContext context;
        private ProductCostHistory history;

        public ProductCostHistoryServiceTests()
        {
            context = new TestingContext();
            service = new ProductCostHistoryService(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductCostHistory>().Add(history = ObjectsFactory.CreateProductCostHistory());
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
            ProductCostHistoryView actual = service.Get<ProductCostHistoryView>(history.Id)!;
            ProductCostHistoryView expected = Mapper.Map<ProductCostHistoryView>(history);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsHistoryViews()
        {
            ProductCostHistoryView[] actual = service.GetViews().ToArray();
            ProductCostHistoryView[] expected = context
                .Set<ProductCostHistory>()
                .ProjectTo<ProductCostHistoryView>()
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
            ProductCostHistoryView view = ObjectsFactory.CreateProductCostHistoryView(2);

            service.Create(view);

            ProductCostHistory actual = context.Set<ProductCostHistory>().AsNoTracking().Single(model => model.Id != history.Id);
            ProductCostHistoryView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_History()
        {
            ProductCostHistoryView view = ObjectsFactory.CreateProductCostHistoryView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            ProductCostHistory actual = context.Set<ProductCostHistory>().AsNoTracking().Single();
            ProductCostHistory expected = history;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_History()
        {
            service.Delete(history.Id);

            Assert.Empty(context.Set<ProductCostHistory>());
        }
    }
}
