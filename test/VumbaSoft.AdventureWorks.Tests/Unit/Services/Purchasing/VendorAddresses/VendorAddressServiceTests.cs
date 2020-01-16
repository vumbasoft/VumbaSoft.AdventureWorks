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
    public class VendorAddressServiceTests : IDisposable
    {
        private VendorAddressService service;
        private TestingContext context;
        private VendorAddress address;

        public VendorAddressServiceTests()
        {
            context = new TestingContext();
            service = new VendorAddressService(new UnitOfWork(new TestingContext(context)));

            context.Set<VendorAddress>().Add(address = ObjectsFactory.CreateVendorAddress());
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
            VendorAddressView actual = service.Get<VendorAddressView>(address.Id)!;
            VendorAddressView expected = Mapper.Map<VendorAddressView>(address);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsAddressViews()
        {
            VendorAddressView[] actual = service.GetViews().ToArray();
            VendorAddressView[] expected = context
                .Set<VendorAddress>()
                .ProjectTo<VendorAddressView>()
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
            VendorAddressView view = ObjectsFactory.CreateVendorAddressView(2);

            service.Create(view);

            VendorAddress actual = context.Set<VendorAddress>().AsNoTracking().Single(model => model.Id != address.Id);
            VendorAddressView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Address()
        {
            VendorAddressView view = ObjectsFactory.CreateVendorAddressView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            VendorAddress actual = context.Set<VendorAddress>().AsNoTracking().Single();
            VendorAddress expected = address;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Address()
        {
            service.Delete(address.Id);

            Assert.Empty(context.Set<VendorAddress>());
        }
    }
}
