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
    public class SalesOrderDetailServiceTests : IDisposable
    {
        private SalesOrderDetailService service;
        private TestingContext context;
        private SalesOrderDetail detail;

        public SalesOrderDetailServiceTests()
        {
            context = new TestingContext();
            service = new SalesOrderDetailService(new UnitOfWork(new TestingContext(context)));

            context.Set<SalesOrderDetail>().Add(detail = ObjectsFactory.CreateSalesOrderDetail());
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
            SalesOrderDetailView actual = service.Get<SalesOrderDetailView>(detail.Id)!;
            SalesOrderDetailView expected = Mapper.Map<SalesOrderDetailView>(detail);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsDetailViews()
        {
            SalesOrderDetailView[] actual = service.GetViews().ToArray();
            SalesOrderDetailView[] expected = context
                .Set<SalesOrderDetail>()
                .ProjectTo<SalesOrderDetailView>()
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
            SalesOrderDetailView view = ObjectsFactory.CreateSalesOrderDetailView(2);

            service.Create(view);

            SalesOrderDetail actual = context.Set<SalesOrderDetail>().AsNoTracking().Single(model => model.Id != detail.Id);
            SalesOrderDetailView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Detail()
        {
            SalesOrderDetailView view = ObjectsFactory.CreateSalesOrderDetailView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            SalesOrderDetail actual = context.Set<SalesOrderDetail>().AsNoTracking().Single();
            SalesOrderDetail expected = detail;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Detail()
        {
            service.Delete(detail.Id);

            Assert.Empty(context.Set<SalesOrderDetail>());
        }
    }
}
