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
    public class EmployeeServiceTests : IDisposable
    {
        private EmployeeService service;
        private TestingContext context;
        private Employee employee;

        public EmployeeServiceTests()
        {
            context = new TestingContext();
            service = new EmployeeService(new UnitOfWork(new TestingContext(context)));

            context.Set<Employee>().Add(employee = ObjectsFactory.CreateEmployee());
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
            EmployeeView actual = service.Get<EmployeeView>(employee.Id)!;
            EmployeeView expected = Mapper.Map<EmployeeView>(employee);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsEmployeeViews()
        {
            EmployeeView[] actual = service.GetViews().ToArray();
            EmployeeView[] expected = context
                .Set<Employee>()
                .ProjectTo<EmployeeView>()
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
        public void Create_Employee()
        {
            EmployeeView view = ObjectsFactory.CreateEmployeeView(2);

            service.Create(view);

            Employee actual = context.Set<Employee>().AsNoTracking().Single(model => model.Id != employee.Id);
            EmployeeView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Employee()
        {
            EmployeeView view = ObjectsFactory.CreateEmployeeView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            Employee actual = context.Set<Employee>().AsNoTracking().Single();
            Employee expected = employee;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Employee()
        {
            service.Delete(employee.Id);

            Assert.Empty(context.Set<Employee>());
        }
    }
}
