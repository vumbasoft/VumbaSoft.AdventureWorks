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
    public class ShoppingCartItemServiceTests : IDisposable
    {
        private ShoppingCartItemService service;
        private TestingContext context;
        private ShoppingCartItem item;

        public ShoppingCartItemServiceTests()
        {
            context = new TestingContext();
            service = new ShoppingCartItemService(new UnitOfWork(new TestingContext(context)));

            context.Set<ShoppingCartItem>().Add(item = ObjectsFactory.CreateShoppingCartItem());
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
            ShoppingCartItemView actual = service.Get<ShoppingCartItemView>(item.Id)!;
            ShoppingCartItemView expected = Mapper.Map<ShoppingCartItemView>(item);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsItemViews()
        {
            ShoppingCartItemView[] actual = service.GetViews().ToArray();
            ShoppingCartItemView[] expected = context
                .Set<ShoppingCartItem>()
                .ProjectTo<ShoppingCartItemView>()
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
        public void Create_Item()
        {
            ShoppingCartItemView view = ObjectsFactory.CreateShoppingCartItemView(2);

            service.Create(view);

            ShoppingCartItem actual = context.Set<ShoppingCartItem>().AsNoTracking().Single(model => model.Id != item.Id);
            ShoppingCartItemView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Item()
        {
            ShoppingCartItemView view = ObjectsFactory.CreateShoppingCartItemView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            ShoppingCartItem actual = context.Set<ShoppingCartItem>().AsNoTracking().Single();
            ShoppingCartItem expected = item;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Item()
        {
            service.Delete(item.Id);

            Assert.Empty(context.Set<ShoppingCartItem>());
        }
    }
}
