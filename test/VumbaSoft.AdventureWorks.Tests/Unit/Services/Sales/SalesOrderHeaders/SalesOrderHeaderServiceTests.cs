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
    public class SalesOrderHeaderServiceTests : IDisposable
    {
        private SalesOrderHeaderService service;
        private TestingContext context;
        private SalesOrderHeader header;

        public SalesOrderHeaderServiceTests()
        {
            context = new TestingContext();
            service = new SalesOrderHeaderService(new UnitOfWork(new TestingContext(context)));

            context.Set<SalesOrderHeader>().Add(header = ObjectsFactory.CreateSalesOrderHeader());
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
            SalesOrderHeaderView actual = service.Get<SalesOrderHeaderView>(header.Id)!;
            SalesOrderHeaderView expected = Mapper.Map<SalesOrderHeaderView>(header);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsHeaderViews()
        {
            SalesOrderHeaderView[] actual = service.GetViews().ToArray();
            SalesOrderHeaderView[] expected = context
                .Set<SalesOrderHeader>()
                .ProjectTo<SalesOrderHeaderView>()
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
            SalesOrderHeaderView view = ObjectsFactory.CreateSalesOrderHeaderView(2);

            service.Create(view);

            SalesOrderHeader actual = context.Set<SalesOrderHeader>().AsNoTracking().Single(model => model.Id != header.Id);
            SalesOrderHeaderView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Header()
        {
            SalesOrderHeaderView view = ObjectsFactory.CreateSalesOrderHeaderView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            SalesOrderHeader actual = context.Set<SalesOrderHeader>().AsNoTracking().Single();
            SalesOrderHeader expected = header;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Header()
        {
            service.Delete(header.Id);

            Assert.Empty(context.Set<SalesOrderHeader>());
        }
    }
}
