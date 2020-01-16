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
    public class ProductServiceTests : IDisposable
    {
        private ProductService service;
        private TestingContext context;
        private Product product;

        public ProductServiceTests()
        {
            context = new TestingContext();
            service = new ProductService(new UnitOfWork(new TestingContext(context)));

            context.Set<Product>().Add(product = ObjectsFactory.CreateProduct());
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
            ProductView actual = service.Get<ProductView>(product.Id)!;
            ProductView expected = Mapper.Map<ProductView>(product);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsProductViews()
        {
            ProductView[] actual = service.GetViews().ToArray();
            ProductView[] expected = context
                .Set<Product>()
                .ProjectTo<ProductView>()
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
        public void Create_Product()
        {
            ProductView view = ObjectsFactory.CreateProductView(2);

            service.Create(view);

            Product actual = context.Set<Product>().AsNoTracking().Single(model => model.Id != product.Id);
            ProductView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Product()
        {
            ProductView view = ObjectsFactory.CreateProductView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            Product actual = context.Set<Product>().AsNoTracking().Single();
            Product expected = product;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Product()
        {
            service.Delete(product.Id);

            Assert.Empty(context.Set<Product>());
        }
    }
}
