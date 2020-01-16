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
    public class TransactionHistoryArchiveServiceTests : IDisposable
    {
        private TransactionHistoryArchiveService service;
        private TestingContext context;
        private TransactionHistoryArchive archive;

        public TransactionHistoryArchiveServiceTests()
        {
            context = new TestingContext();
            service = new TransactionHistoryArchiveService(new UnitOfWork(new TestingContext(context)));

            context.Set<TransactionHistoryArchive>().Add(archive = ObjectsFactory.CreateTransactionHistoryArchive());
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
            TransactionHistoryArchiveView actual = service.Get<TransactionHistoryArchiveView>(archive.Id)!;
            TransactionHistoryArchiveView expected = Mapper.Map<TransactionHistoryArchiveView>(archive);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsArchiveViews()
        {
            TransactionHistoryArchiveView[] actual = service.GetViews().ToArray();
            TransactionHistoryArchiveView[] expected = context
                .Set<TransactionHistoryArchive>()
                .ProjectTo<TransactionHistoryArchiveView>()
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
        public void Create_Archive()
        {
            TransactionHistoryArchiveView view = ObjectsFactory.CreateTransactionHistoryArchiveView(2);

            service.Create(view);

            TransactionHistoryArchive actual = context.Set<TransactionHistoryArchive>().AsNoTracking().Single(model => model.Id != archive.Id);
            TransactionHistoryArchiveView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Archive()
        {
            TransactionHistoryArchiveView view = ObjectsFactory.CreateTransactionHistoryArchiveView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            TransactionHistoryArchive actual = context.Set<TransactionHistoryArchive>().AsNoTracking().Single();
            TransactionHistoryArchive expected = archive;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Archive()
        {
            service.Delete(archive.Id);

            Assert.Empty(context.Set<TransactionHistoryArchive>());
        }
    }
}
