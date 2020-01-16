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
    public class SalesPersonQuotaHistoryServiceTests : IDisposable
    {
        private SalesPersonQuotaHistoryService service;
        private TestingContext context;
        private SalesPersonQuotaHistory history;

        public SalesPersonQuotaHistoryServiceTests()
        {
            context = new TestingContext();
            service = new SalesPersonQuotaHistoryService(new UnitOfWork(new TestingContext(context)));

            context.Set<SalesPersonQuotaHistory>().Add(history = ObjectsFactory.CreateSalesPersonQuotaHistory());
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
            SalesPersonQuotaHistoryView actual = service.Get<SalesPersonQuotaHistoryView>(history.Id)!;
            SalesPersonQuotaHistoryView expected = Mapper.Map<SalesPersonQuotaHistoryView>(history);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsHistoryViews()
        {
            SalesPersonQuotaHistoryView[] actual = service.GetViews().ToArray();
            SalesPersonQuotaHistoryView[] expected = context
                .Set<SalesPersonQuotaHistory>()
                .ProjectTo<SalesPersonQuotaHistoryView>()
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
        public void Create_History()
        {
            SalesPersonQuotaHistoryView view = ObjectsFactory.CreateSalesPersonQuotaHistoryView(2);

            service.Create(view);

            SalesPersonQuotaHistory actual = context.Set<SalesPersonQuotaHistory>().AsNoTracking().Single(model => model.Id != history.Id);
            SalesPersonQuotaHistoryView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_History()
        {
            SalesPersonQuotaHistoryView view = ObjectsFactory.CreateSalesPersonQuotaHistoryView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            SalesPersonQuotaHistory actual = context.Set<SalesPersonQuotaHistory>().AsNoTracking().Single();
            SalesPersonQuotaHistory expected = history;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_History()
        {
            service.Delete(history.Id);

            Assert.Empty(context.Set<SalesPersonQuotaHistory>());
        }
    }
}
