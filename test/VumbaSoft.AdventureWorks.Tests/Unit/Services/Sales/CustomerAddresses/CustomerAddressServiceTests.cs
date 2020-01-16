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
    public class CustomerAddressServiceTests : IDisposable
    {
        private CustomerAddressService service;
        private TestingContext context;
        private CustomerAddress address;

        public CustomerAddressServiceTests()
        {
            context = new TestingContext();
            service = new CustomerAddressService(new UnitOfWork(new TestingContext(context)));

            context.Set<CustomerAddress>().Add(address = ObjectsFactory.CreateCustomerAddress());
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
            CustomerAddressView actual = service.Get<CustomerAddressView>(address.Id)!;
            CustomerAddressView expected = Mapper.Map<CustomerAddressView>(address);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsAddressViews()
        {
            CustomerAddressView[] actual = service.GetViews().ToArray();
            CustomerAddressView[] expected = context
                .Set<CustomerAddress>()
                .ProjectTo<CustomerAddressView>()
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
            CustomerAddressView view = ObjectsFactory.CreateCustomerAddressView(2);

            service.Create(view);

            CustomerAddress actual = context.Set<CustomerAddress>().AsNoTracking().Single(model => model.Id != address.Id);
            CustomerAddressView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Address()
        {
            CustomerAddressView view = ObjectsFactory.CreateCustomerAddressView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            CustomerAddress actual = context.Set<CustomerAddress>().AsNoTracking().Single();
            CustomerAddress expected = address;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Address()
        {
            service.Delete(address.Id);

            Assert.Empty(context.Set<CustomerAddress>());
        }
    }
}
