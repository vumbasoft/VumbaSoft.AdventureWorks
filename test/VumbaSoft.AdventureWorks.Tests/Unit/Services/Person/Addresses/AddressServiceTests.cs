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
    public class AddressServiceTests : IDisposable
    {
        private AddressService service;
        private TestingContext context;
        private Address address;

        public AddressServiceTests()
        {
            context = new TestingContext();
            service = new AddressService(new UnitOfWork(new TestingContext(context)));

            context.Set<Address>().Add(address = ObjectsFactory.CreateAddress());
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
            AddressView actual = service.Get<AddressView>(address.Id)!;
            AddressView expected = Mapper.Map<AddressView>(address);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsAddressViews()
        {
            AddressView[] actual = service.GetViews().ToArray();
            AddressView[] expected = context
                .Set<Address>()
                .ProjectTo<AddressView>()
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
            AddressView view = ObjectsFactory.CreateAddressView(2);

            service.Create(view);

            Address actual = context.Set<Address>().AsNoTracking().Single(model => model.Id != address.Id);
            AddressView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Address()
        {
            AddressView view = ObjectsFactory.CreateAddressView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            Address actual = context.Set<Address>().AsNoTracking().Single();
            Address expected = address;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Address()
        {
            service.Delete(address.Id);

            Assert.Empty(context.Set<Address>());
        }
    }
}
