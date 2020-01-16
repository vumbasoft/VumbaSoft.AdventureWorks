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
    public class SalesReasonServiceTests : IDisposable
    {
        private SalesReasonService service;
        private TestingContext context;
        private SalesReason reason;

        public SalesReasonServiceTests()
        {
            context = new TestingContext();
            service = new SalesReasonService(new UnitOfWork(new TestingContext(context)));

            context.Set<SalesReason>().Add(reason = ObjectsFactory.CreateSalesReason());
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
            SalesReasonView actual = service.Get<SalesReasonView>(reason.Id)!;
            SalesReasonView expected = Mapper.Map<SalesReasonView>(reason);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsReasonViews()
        {
            SalesReasonView[] actual = service.GetViews().ToArray();
            SalesReasonView[] expected = context
                .Set<SalesReason>()
                .ProjectTo<SalesReasonView>()
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
            SalesReasonView view = ObjectsFactory.CreateSalesReasonView(2);

            service.Create(view);

            SalesReason actual = context.Set<SalesReason>().AsNoTracking().Single(model => model.Id != reason.Id);
            SalesReasonView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Reason()
        {
            SalesReasonView view = ObjectsFactory.CreateSalesReasonView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            SalesReason actual = context.Set<SalesReason>().AsNoTracking().Single();
            SalesReason expected = reason;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Reason()
        {
            service.Delete(reason.Id);

            Assert.Empty(context.Set<SalesReason>());
        }
    }
}
