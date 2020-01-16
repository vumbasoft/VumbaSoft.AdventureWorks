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
    public class PurchaseOrderDetailServiceTests : IDisposable
    {
        private PurchaseOrderDetailService service;
        private TestingContext context;
        private PurchaseOrderDetail detail;

        public PurchaseOrderDetailServiceTests()
        {
            context = new TestingContext();
            service = new PurchaseOrderDetailService(new UnitOfWork(new TestingContext(context)));

            context.Set<PurchaseOrderDetail>().Add(detail = ObjectsFactory.CreatePurchaseOrderDetail());
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
            PurchaseOrderDetailView actual = service.Get<PurchaseOrderDetailView>(detail.Id)!;
            PurchaseOrderDetailView expected = Mapper.Map<PurchaseOrderDetailView>(detail);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsDetailViews()
        {
            PurchaseOrderDetailView[] actual = service.GetViews().ToArray();
            PurchaseOrderDetailView[] expected = context
                .Set<PurchaseOrderDetail>()
                .ProjectTo<PurchaseOrderDetailView>()
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
        public void Create_Detail()
        {
            PurchaseOrderDetailView view = ObjectsFactory.CreatePurchaseOrderDetailView(2);

            service.Create(view);

            PurchaseOrderDetail actual = context.Set<PurchaseOrderDetail>().AsNoTracking().Single(model => model.Id != detail.Id);
            PurchaseOrderDetailView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Detail()
        {
            PurchaseOrderDetailView view = ObjectsFactory.CreatePurchaseOrderDetailView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            PurchaseOrderDetail actual = context.Set<PurchaseOrderDetail>().AsNoTracking().Single();
            PurchaseOrderDetail expected = detail;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Detail()
        {
            service.Delete(detail.Id);

            Assert.Empty(context.Set<PurchaseOrderDetail>());
        }
    }
}
