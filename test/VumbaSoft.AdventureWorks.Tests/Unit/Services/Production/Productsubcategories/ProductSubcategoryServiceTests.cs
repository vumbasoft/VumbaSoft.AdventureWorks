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
    public class ProductSubcategoryServiceTests : IDisposable
    {
        private ProductSubcategoryService service;
        private TestingContext context;
        private ProductSubcategory subcategory;

        public ProductSubcategoryServiceTests()
        {
            context = new TestingContext();
            service = new ProductSubcategoryService(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductSubcategory>().Add(subcategory = ObjectsFactory.CreateProductSubcategory());
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
            ProductSubcategoryView actual = service.Get<ProductSubcategoryView>(subcategory.Id)!;
            ProductSubcategoryView expected = Mapper.Map<ProductSubcategoryView>(subcategory);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsSubcategoryViews()
        {
            ProductSubcategoryView[] actual = service.GetViews().ToArray();
            ProductSubcategoryView[] expected = context
                .Set<ProductSubcategory>()
                .ProjectTo<ProductSubcategoryView>()
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
        public void Create_Subcategory()
        {
            ProductSubcategoryView view = ObjectsFactory.CreateProductSubcategoryView(2);

            service.Create(view);

            ProductSubcategory actual = context.Set<ProductSubcategory>().AsNoTracking().Single(model => model.Id != subcategory.Id);
            ProductSubcategoryView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Subcategory()
        {
            ProductSubcategoryView view = ObjectsFactory.CreateProductSubcategoryView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            ProductSubcategory actual = context.Set<ProductSubcategory>().AsNoTracking().Single();
            ProductSubcategory expected = subcategory;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Subcategory()
        {
            service.Delete(subcategory.Id);

            Assert.Empty(context.Set<ProductSubcategory>());
        }
    }
}
