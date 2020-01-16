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
    public class DepartmentServiceTests : IDisposable
    {
        private DepartmentService service;
        private TestingContext context;
        private Department department;

        public DepartmentServiceTests()
        {
            context = new TestingContext();
            service = new DepartmentService(new UnitOfWork(new TestingContext(context)));

            context.Set<Department>().Add(department = ObjectsFactory.CreateDepartment());
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
            DepartmentView actual = service.Get<DepartmentView>(department.Id)!;
            DepartmentView expected = Mapper.Map<DepartmentView>(department);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsDepartmentViews()
        {
            DepartmentView[] actual = service.GetViews().ToArray();
            DepartmentView[] expected = context
                .Set<Department>()
                .ProjectTo<DepartmentView>()
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
        public void Create_Department()
        {
            DepartmentView view = ObjectsFactory.CreateDepartmentView(2);

            service.Create(view);

            Department actual = context.Set<Department>().AsNoTracking().Single(model => model.Id != department.Id);
            DepartmentView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Department()
        {
            DepartmentView view = ObjectsFactory.CreateDepartmentView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            Department actual = context.Set<Department>().AsNoTracking().Single();
            Department expected = department;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Department()
        {
            service.Delete(department.Id);

            Assert.Empty(context.Set<Department>());
        }
    }
}
