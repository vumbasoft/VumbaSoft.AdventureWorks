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
    public class PurchaseOrderHeaderServiceTests : IDisposable
    {
        private PurchaseOrderHeaderService service;
        private TestingContext context;
        private PurchaseOrderHeader header;

        public PurchaseOrderHeaderServiceTests()
        {
            context = new TestingContext();
            service = new PurchaseOrderHeaderService(new UnitOfWork(new TestingContext(context)));

            context.Set<PurchaseOrderHeader>().Add(header = ObjectsFactory.CreatePurchaseOrderHeader());
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
            PurchaseOrderHeaderView actual = service.Get<PurchaseOrderHeaderView>(header.Id)!;
            PurchaseOrderHeaderView expected = Mapper.Map<PurchaseOrderHeaderView>(header);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsHeaderViews()
        {
            PurchaseOrderHeaderView[] actual = service.GetViews().ToArray();
            PurchaseOrderHeaderView[] expected = context
                .Set<PurchaseOrderHeader>()
                .ProjectTo<PurchaseOrderHeaderView>()
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
        public void Create_Header()
        {
            PurchaseOrderHeaderView view = ObjectsFactory.CreatePurchaseOrderHeaderView(2);

            service.Create(view);

            PurchaseOrderHeader actual = context.Set<PurchaseOrderHeader>().AsNoTracking().Single(model => model.Id != header.Id);
            PurchaseOrderHeaderView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Header()
        {
            PurchaseOrderHeaderView view = ObjectsFactory.CreatePurchaseOrderHeaderView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            PurchaseOrderHeader actual = context.Set<PurchaseOrderHeader>().AsNoTracking().Single();
            PurchaseOrderHeader expected = header;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Header()
        {
            service.Delete(header.Id);

            Assert.Empty(context.Set<PurchaseOrderHeader>());
        }
    }
}
