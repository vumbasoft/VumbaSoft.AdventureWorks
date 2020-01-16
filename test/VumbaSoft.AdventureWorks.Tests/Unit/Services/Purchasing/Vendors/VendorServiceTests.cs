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
    public class VendorServiceTests : IDisposable
    {
        private VendorService service;
        private TestingContext context;
        private Vendor vendor;

        public VendorServiceTests()
        {
            context = new TestingContext();
            service = new VendorService(new UnitOfWork(new TestingContext(context)));

            context.Set<Vendor>().Add(vendor = ObjectsFactory.CreateVendor());
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
            VendorView actual = service.Get<VendorView>(vendor.Id)!;
            VendorView expected = Mapper.Map<VendorView>(vendor);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsVendorViews()
        {
            VendorView[] actual = service.GetViews().ToArray();
            VendorView[] expected = context
                .Set<Vendor>()
                .ProjectTo<VendorView>()
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
        public void Create_Vendor()
        {
            VendorView view = ObjectsFactory.CreateVendorView(2);

            service.Create(view);

            Vendor actual = context.Set<Vendor>().AsNoTracking().Single(model => model.Id != vendor.Id);
            VendorView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Vendor()
        {
            VendorView view = ObjectsFactory.CreateVendorView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            Vendor actual = context.Set<Vendor>().AsNoTracking().Single();
            Vendor expected = vendor;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Vendor()
        {
            service.Delete(vendor.Id);

            Assert.Empty(context.Set<Vendor>());
        }
    }
}
