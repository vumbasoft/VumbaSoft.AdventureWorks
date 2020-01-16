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
    public class ProductCategoryServiceTests : IDisposable
    {
        private ProductCategoryService service;
        private TestingContext context;
        private ProductCategory category;

        public ProductCategoryServiceTests()
        {
            context = new TestingContext();
            service = new ProductCategoryService(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductCategory>().Add(category = ObjectsFactory.CreateProductCategory());
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
            ProductCategoryView actual = service.Get<ProductCategoryView>(category.Id)!;
            ProductCategoryView expected = Mapper.Map<ProductCategoryView>(category);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsCategoryViews()
        {
            ProductCategoryView[] actual = service.GetViews().ToArray();
            ProductCategoryView[] expected = context
                .Set<ProductCategory>()
                .ProjectTo<ProductCategoryView>()
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
        public void Create_Category()
        {
            ProductCategoryView view = ObjectsFactory.CreateProductCategoryView(2);

            service.Create(view);

            ProductCategory actual = context.Set<ProductCategory>().AsNoTracking().Single(model => model.Id != category.Id);
            ProductCategoryView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Category()
        {
            ProductCategoryView view = ObjectsFactory.CreateProductCategoryView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            ProductCategory actual = context.Set<ProductCategory>().AsNoTracking().Single();
            ProductCategory expected = category;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Category()
        {
            service.Delete(category.Id);

            Assert.Empty(context.Set<ProductCategory>());
        }
    }
}
