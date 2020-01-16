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
    public class StoreServiceTests : IDisposable
    {
        private StoreService service;
        private TestingContext context;
        private Store store;

        public StoreServiceTests()
        {
            context = new TestingContext();
            service = new StoreService(new UnitOfWork(new TestingContext(context)));

            context.Set<Store>().Add(store = ObjectsFactory.CreateStore());
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
            StoreView actual = service.Get<StoreView>(store.Id)!;
            StoreView expected = Mapper.Map<StoreView>(store);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsStoreViews()
        {
            StoreView[] actual = service.GetViews().ToArray();
            StoreView[] expected = context
                .Set<Store>()
                .ProjectTo<StoreView>()
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
        public void Create_Store()
        {
            StoreView view = ObjectsFactory.CreateStoreView(2);

            service.Create(view);

            Store actual = context.Set<Store>().AsNoTracking().Single(model => model.Id != store.Id);
            StoreView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Store()
        {
            StoreView view = ObjectsFactory.CreateStoreView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            Store actual = context.Set<Store>().AsNoTracking().Single();
            Store expected = store;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Store()
        {
            service.Delete(store.Id);

            Assert.Empty(context.Set<Store>());
        }
    }
}
