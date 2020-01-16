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
    public class StoreContactServiceTests : IDisposable
    {
        private StoreContactService service;
        private TestingContext context;
        private StoreContact contact;

        public StoreContactServiceTests()
        {
            context = new TestingContext();
            service = new StoreContactService(new UnitOfWork(new TestingContext(context)));

            context.Set<StoreContact>().Add(contact = ObjectsFactory.CreateStoreContact());
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
            StoreContactView actual = service.Get<StoreContactView>(contact.Id)!;
            StoreContactView expected = Mapper.Map<StoreContactView>(contact);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsContactViews()
        {
            StoreContactView[] actual = service.GetViews().ToArray();
            StoreContactView[] expected = context
                .Set<StoreContact>()
                .ProjectTo<StoreContactView>()
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
        public void Create_Contact()
        {
            StoreContactView view = ObjectsFactory.CreateStoreContactView(2);

            service.Create(view);

            StoreContact actual = context.Set<StoreContact>().AsNoTracking().Single(model => model.Id != contact.Id);
            StoreContactView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Contact()
        {
            StoreContactView view = ObjectsFactory.CreateStoreContactView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            StoreContact actual = context.Set<StoreContact>().AsNoTracking().Single();
            StoreContact expected = contact;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Contact()
        {
            service.Delete(contact.Id);

            Assert.Empty(context.Set<StoreContact>());
        }
    }
}
