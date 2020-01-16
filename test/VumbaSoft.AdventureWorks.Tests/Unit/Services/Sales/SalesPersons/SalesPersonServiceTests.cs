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
    public class SalesPersonServiceTests : IDisposable
    {
        private SalesPersonService service;
        private TestingContext context;
        private SalesPerson person;

        public SalesPersonServiceTests()
        {
            context = new TestingContext();
            service = new SalesPersonService(new UnitOfWork(new TestingContext(context)));

            context.Set<SalesPerson>().Add(person = ObjectsFactory.CreateSalesPerson());
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
            SalesPersonView actual = service.Get<SalesPersonView>(person.Id)!;
            SalesPersonView expected = Mapper.Map<SalesPersonView>(person);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsPersonViews()
        {
            SalesPersonView[] actual = service.GetViews().ToArray();
            SalesPersonView[] expected = context
                .Set<SalesPerson>()
                .ProjectTo<SalesPersonView>()
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
        public void Create_Person()
        {
            SalesPersonView view = ObjectsFactory.CreateSalesPersonView(2);

            service.Create(view);

            SalesPerson actual = context.Set<SalesPerson>().AsNoTracking().Single(model => model.Id != person.Id);
            SalesPersonView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Person()
        {
            SalesPersonView view = ObjectsFactory.CreateSalesPersonView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            SalesPerson actual = context.Set<SalesPerson>().AsNoTracking().Single();
            SalesPerson expected = person;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Person()
        {
            service.Delete(person.Id);

            Assert.Empty(context.Set<SalesPerson>());
        }
    }
}
