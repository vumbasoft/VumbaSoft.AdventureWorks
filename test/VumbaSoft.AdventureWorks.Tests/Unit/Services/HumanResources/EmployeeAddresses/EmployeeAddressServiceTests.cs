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
    public class EmployeeAddressServiceTests : IDisposable
    {
        private EmployeeAddressService service;
        private TestingContext context;
        private EmployeeAddress address;

        public EmployeeAddressServiceTests()
        {
            context = new TestingContext();
            service = new EmployeeAddressService(new UnitOfWork(new TestingContext(context)));

            context.Set<EmployeeAddress>().Add(address = ObjectsFactory.CreateEmployeeAddress());
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
            EmployeeAddressView actual = service.Get<EmployeeAddressView>(address.Id)!;
            EmployeeAddressView expected = Mapper.Map<EmployeeAddressView>(address);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsAddressViews()
        {
            EmployeeAddressView[] actual = service.GetViews().ToArray();
            EmployeeAddressView[] expected = context
                .Set<EmployeeAddress>()
                .ProjectTo<EmployeeAddressView>()
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
        public void Create_Address()
        {
            EmployeeAddressView view = ObjectsFactory.CreateEmployeeAddressView(2);

            service.Create(view);

            EmployeeAddress actual = context.Set<EmployeeAddress>().AsNoTracking().Single(model => model.Id != address.Id);
            EmployeeAddressView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Address()
        {
            EmployeeAddressView view = ObjectsFactory.CreateEmployeeAddressView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            EmployeeAddress actual = context.Set<EmployeeAddress>().AsNoTracking().Single();
            EmployeeAddress expected = address;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Address()
        {
            service.Delete(address.Id);

            Assert.Empty(context.Set<EmployeeAddress>());
        }
    }
}
