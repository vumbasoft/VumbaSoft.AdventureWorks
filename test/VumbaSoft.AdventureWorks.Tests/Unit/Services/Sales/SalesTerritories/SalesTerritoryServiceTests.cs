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
    public class SalesTerritoryServiceTests : IDisposable
    {
        private SalesTerritoryService service;
        private TestingContext context;
        private SalesTerritory territory;

        public SalesTerritoryServiceTests()
        {
            context = new TestingContext();
            service = new SalesTerritoryService(new UnitOfWork(new TestingContext(context)));

            context.Set<SalesTerritory>().Add(territory = ObjectsFactory.CreateSalesTerritory());
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
            SalesTerritoryView actual = service.Get<SalesTerritoryView>(territory.Id)!;
            SalesTerritoryView expected = Mapper.Map<SalesTerritoryView>(territory);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsTerritoryViews()
        {
            SalesTerritoryView[] actual = service.GetViews().ToArray();
            SalesTerritoryView[] expected = context
                .Set<SalesTerritory>()
                .ProjectTo<SalesTerritoryView>()
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
        public void Create_Territory()
        {
            SalesTerritoryView view = ObjectsFactory.CreateSalesTerritoryView(2);

            service.Create(view);

            SalesTerritory actual = context.Set<SalesTerritory>().AsNoTracking().Single(model => model.Id != territory.Id);
            SalesTerritoryView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Territory()
        {
            SalesTerritoryView view = ObjectsFactory.CreateSalesTerritoryView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            SalesTerritory actual = context.Set<SalesTerritory>().AsNoTracking().Single();
            SalesTerritory expected = territory;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Territory()
        {
            service.Delete(territory.Id);

            Assert.Empty(context.Set<SalesTerritory>());
        }
    }
}
