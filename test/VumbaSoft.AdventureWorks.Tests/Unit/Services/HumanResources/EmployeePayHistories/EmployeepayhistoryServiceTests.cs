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
    public class EmployeepayhistoryServiceTests : IDisposable
    {
        private EmployeepayhistoryService service;
        private TestingContext context;
        private EmployeePayHistory employeepayhistory;

        public EmployeepayhistoryServiceTests()
        {
            context = new TestingContext();
            service = new EmployeepayhistoryService(new UnitOfWork(new TestingContext(context)));

            context.Set<EmployeePayHistory>().Add(employeepayhistory = ObjectsFactory.CreateEmployeepayhistory());
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
            EmployeePayHistoryView actual = service.Get<EmployeePayHistoryView>(employeepayhistory.Id)!;
            EmployeePayHistoryView expected = Mapper.Map<EmployeePayHistoryView>(employeepayhistory);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsEmployeepayhistoryViews()
        {
            EmployeePayHistoryView[] actual = service.GetViews().ToArray();
            EmployeePayHistoryView[] expected = context
                .Set<EmployeePayHistory>()
                .ProjectTo<EmployeePayHistoryView>()
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
        public void Create_Employeepayhistory()
        {
            EmployeePayHistoryView view = ObjectsFactory.CreateEmployeepayhistoryView(2);

            service.Create(view);

            EmployeePayHistory actual = context.Set<EmployeePayHistory>().AsNoTracking().Single(model => model.Id != employeepayhistory.Id);
            EmployeePayHistoryView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Employeepayhistory()
        {
            EmployeePayHistoryView view = ObjectsFactory.CreateEmployeepayhistoryView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            EmployeePayHistory actual = context.Set<EmployeePayHistory>().AsNoTracking().Single();
            EmployeePayHistory expected = employeepayhistory;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Employeepayhistory()
        {
            service.Delete(employeepayhistory.Id);

            Assert.Empty(context.Set<EmployeePayHistory>());
        }
    }
}
