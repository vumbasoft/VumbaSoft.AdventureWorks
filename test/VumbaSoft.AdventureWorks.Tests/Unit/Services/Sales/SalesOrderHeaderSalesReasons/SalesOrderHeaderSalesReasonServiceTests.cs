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
    public class SalesOrderHeaderSalesReasonServiceTests : IDisposable
    {
        private SalesOrderHeaderSalesReasonService service;
        private TestingContext context;
        private SalesOrderHeaderSalesReason reason;

        public SalesOrderHeaderSalesReasonServiceTests()
        {
            context = new TestingContext();
            service = new SalesOrderHeaderSalesReasonService(new UnitOfWork(new TestingContext(context)));

            context.Set<SalesOrderHeaderSalesReason>().Add(reason = ObjectsFactory.CreateSalesOrderHeaderSalesReason());
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
            SalesOrderHeaderSalesReasonView actual = service.Get<SalesOrderHeaderSalesReasonView>(reason.Id)!;
            SalesOrderHeaderSalesReasonView expected = Mapper.Map<SalesOrderHeaderSalesReasonView>(reason);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsReasonViews()
        {
            SalesOrderHeaderSalesReasonView[] actual = service.GetViews().ToArray();
            SalesOrderHeaderSalesReasonView[] expected = context
                .Set<SalesOrderHeaderSalesReason>()
                .ProjectTo<SalesOrderHeaderSalesReasonView>()
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
        public void Create_Reason()
        {
            SalesOrderHeaderSalesReasonView view = ObjectsFactory.CreateSalesOrderHeaderSalesReasonView(2);

            service.Create(view);

            SalesOrderHeaderSalesReason actual = context.Set<SalesOrderHeaderSalesReason>().AsNoTracking().Single(model => model.Id != reason.Id);
            SalesOrderHeaderSalesReasonView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Reason()
        {
            SalesOrderHeaderSalesReasonView view = ObjectsFactory.CreateSalesOrderHeaderSalesReasonView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            SalesOrderHeaderSalesReason actual = context.Set<SalesOrderHeaderSalesReason>().AsNoTracking().Single();
            SalesOrderHeaderSalesReason expected = reason;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Reason()
        {
            service.Delete(reason.Id);

            Assert.Empty(context.Set<SalesOrderHeaderSalesReason>());
        }
    }
}
