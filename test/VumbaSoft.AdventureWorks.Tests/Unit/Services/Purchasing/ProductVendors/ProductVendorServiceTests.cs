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
    public class ProductVendorServiceTests : IDisposable
    {
        private ProductVendorService service;
        private TestingContext context;
        private ProductVendor vendor;

        public ProductVendorServiceTests()
        {
            context = new TestingContext();
            service = new ProductVendorService(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductVendor>().Add(vendor = ObjectsFactory.CreateProductVendor());
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
            ProductVendorView actual = service.Get<ProductVendorView>(vendor.Id)!;
            ProductVendorView expected = Mapper.Map<ProductVendorView>(vendor);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsVendorViews()
        {
            ProductVendorView[] actual = service.GetViews().ToArray();
            ProductVendorView[] expected = context
                .Set<ProductVendor>()
                .ProjectTo<ProductVendorView>()
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
            ProductVendorView view = ObjectsFactory.CreateProductVendorView(2);

            service.Create(view);

            ProductVendor actual = context.Set<ProductVendor>().AsNoTracking().Single(model => model.Id != vendor.Id);
            ProductVendorView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Vendor()
        {
            ProductVendorView view = ObjectsFactory.CreateProductVendorView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            ProductVendor actual = context.Set<ProductVendor>().AsNoTracking().Single();
            ProductVendor expected = vendor;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Vendor()
        {
            service.Delete(vendor.Id);

            Assert.Empty(context.Set<ProductVendor>());
        }
    }
}
