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
    public class TransactionHistoryServiceTests : IDisposable
    {
        private TransactionHistoryService service;
        private TestingContext context;
        private TransactionHistory history;

        public TransactionHistoryServiceTests()
        {
            context = new TestingContext();
            service = new TransactionHistoryService(new UnitOfWork(new TestingContext(context)));

            context.Set<TransactionHistory>().Add(history = ObjectsFactory.CreateTransactionHistory());
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
            TransactionHistoryView actual = service.Get<TransactionHistoryView>(history.Id)!;
            TransactionHistoryView expected = Mapper.Map<TransactionHistoryView>(history);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsHistoryViews()
        {
            TransactionHistoryView[] actual = service.GetViews().ToArray();
            TransactionHistoryView[] expected = context
                .Set<TransactionHistory>()
                .ProjectTo<TransactionHistoryView>()
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
            TransactionHistoryView view = ObjectsFactory.CreateTransactionHistoryView(2);

            service.Create(view);

            TransactionHistory actual = context.Set<TransactionHistory>().AsNoTracking().Single(model => model.Id != history.Id);
            TransactionHistoryView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_History()
        {
            TransactionHistoryView view = ObjectsFactory.CreateTransactionHistoryView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            TransactionHistory actual = context.Set<TransactionHistory>().AsNoTracking().Single();
            TransactionHistory expected = history;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_History()
        {
            service.Delete(history.Id);

            Assert.Empty(context.Set<TransactionHistory>());
        }
    }
}
