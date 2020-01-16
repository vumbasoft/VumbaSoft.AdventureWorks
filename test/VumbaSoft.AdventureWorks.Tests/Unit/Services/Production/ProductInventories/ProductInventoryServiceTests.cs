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
    public class ProductInventoryServiceTests : IDisposable
    {
        private ProductInventoryService service;
        private TestingContext context;
        private ProductInventory inventory;

        public ProductInventoryServiceTests()
        {
            context = new TestingContext();
            service = new ProductInventoryService(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductInventory>().Add(inventory = ObjectsFactory.CreateProductInventory());
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
            ProductInventoryView actual = service.Get<ProductInventoryView>(inventory.Id)!;
            ProductInventoryView expected = Mapper.Map<ProductInventoryView>(inventory);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsInventoryViews()
        {
            ProductInventoryView[] actual = service.GetViews().ToArray();
            ProductInventoryView[] expected = context
                .Set<ProductInventory>()
                .ProjectTo<ProductInventoryView>()
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
        public void Create_Inventory()
        {
            ProductInventoryView view = ObjectsFactory.CreateProductInventoryView(2);

            service.Create(view);

            ProductInventory actual = context.Set<ProductInventory>().AsNoTracking().Single(model => model.Id != inventory.Id);
            ProductInventoryView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Inventory()
        {
            ProductInventoryView view = ObjectsFactory.CreateProductInventoryView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            ProductInventory actual = context.Set<ProductInventory>().AsNoTracking().Single();
            ProductInventory expected = inventory;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Inventory()
        {
            service.Delete(inventory.Id);

            Assert.Empty(context.Set<ProductInventory>());
        }
    }
}
