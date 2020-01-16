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
    public class SalesTerritoryHistoryServiceTests : IDisposable
    {
        private SalesTerritoryHistoryService service;
        private TestingContext context;
        private SalesTerritoryHistory history;

        public SalesTerritoryHistoryServiceTests()
        {
            context = new TestingContext();
            service = new SalesTerritoryHistoryService(new UnitOfWork(new TestingContext(context)));

            context.Set<SalesTerritoryHistory>().Add(history = ObjectsFactory.CreateSalesTerritoryHistory());
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
            SalesTerritoryHistoryView actual = service.Get<SalesTerritoryHistoryView>(history.Id)!;
            SalesTerritoryHistoryView expected = Mapper.Map<SalesTerritoryHistoryView>(history);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsHistoryViews()
        {
            SalesTerritoryHistoryView[] actual = service.GetViews().ToArray();
            SalesTerritoryHistoryView[] expected = context
                .Set<SalesTerritoryHistory>()
                .ProjectTo<SalesTerritoryHistoryView>()
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
            SalesTerritoryHistoryView view = ObjectsFactory.CreateSalesTerritoryHistoryView(2);

            service.Create(view);

            SalesTerritoryHistory actual = context.Set<SalesTerritoryHistory>().AsNoTracking().Single(model => model.Id != history.Id);
            SalesTerritoryHistoryView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_History()
        {
            SalesTerritoryHistoryView view = ObjectsFactory.CreateSalesTerritoryHistoryView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            SalesTerritoryHistory actual = context.Set<SalesTerritoryHistory>().AsNoTracking().Single();
            SalesTerritoryHistory expected = history;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_History()
        {
            service.Delete(history.Id);

            Assert.Empty(context.Set<SalesTerritoryHistory>());
        }
    }
}
