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
    public class EmployeedepartmenthistoryServiceTests : IDisposable
    {
        private EmployeedepartmenthistoryService service;
        private TestingContext context;
        private EmployeeDepartmentHistory employeedepartmenthistory;

        public EmployeedepartmenthistoryServiceTests()
        {
            context = new TestingContext();
            service = new EmployeedepartmenthistoryService(new UnitOfWork(new TestingContext(context)));

            context.Set<EmployeeDepartmentHistory>().Add(employeedepartmenthistory = ObjectsFactory.CreateEmployeedepartmenthistory());
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
            EmployeeDepartmentHistoryView actual = service.Get<EmployeeDepartmentHistoryView>(employeedepartmenthistory.Id)!;
            EmployeeDepartmentHistoryView expected = Mapper.Map<EmployeeDepartmentHistoryView>(employeedepartmenthistory);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsEmployeedepartmenthistoryViews()
        {
            EmployeeDepartmentHistoryView[] actual = service.GetViews().ToArray();
            EmployeeDepartmentHistoryView[] expected = context
                .Set<EmployeeDepartmentHistory>()
                .ProjectTo<EmployeeDepartmentHistoryView>()
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
        public void Create_Employeedepartmenthistory()
        {
            EmployeeDepartmentHistoryView view = ObjectsFactory.CreateEmployeedepartmenthistoryView(2);

            service.Create(view);

            EmployeeDepartmentHistory actual = context.Set<EmployeeDepartmentHistory>().AsNoTracking().Single(model => model.Id != employeedepartmenthistory.Id);
            EmployeeDepartmentHistoryView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Employeedepartmenthistory()
        {
            EmployeeDepartmentHistoryView view = ObjectsFactory.CreateEmployeedepartmenthistoryView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            EmployeeDepartmentHistory actual = context.Set<EmployeeDepartmentHistory>().AsNoTracking().Single();
            EmployeeDepartmentHistory expected = employeedepartmenthistory;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Employeedepartmenthistory()
        {
            service.Delete(employeedepartmenthistory.Id);

            Assert.Empty(context.Set<EmployeeDepartmentHistory>());
        }
    }
}
