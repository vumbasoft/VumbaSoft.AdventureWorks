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
    public class ProductModelServiceTests : IDisposable
    {
        private ProductModelService service;
        private TestingContext context;
        private ProductModel model;

        public ProductModelServiceTests()
        {
            context = new TestingContext();
            service = new ProductModelService(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductModel>().Add(model = ObjectsFactory.CreateProductModel());
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
            ProductModelView actual = service.Get<ProductModelView>(model.Id)!;
            ProductModelView expected = Mapper.Map<ProductModelView>(model);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsModelViews()
        {
            ProductModelView[] actual = service.GetViews().ToArray();
            ProductModelView[] expected = context
                .Set<ProductModel>()
                .ProjectTo<ProductModelView>()
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
        public void Create_Model()
        {
            ProductModelView view = ObjectsFactory.CreateProductModelView(2);

            service.Create(view);

            ProductModel actual = context.Set<ProductModel>().AsNoTracking().Single(model => model.Id != model.Id);
            ProductModelView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Model()
        {
            ProductModelView view = ObjectsFactory.CreateProductModelView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            ProductModel actual = context.Set<ProductModel>().AsNoTracking().Single();
            ProductModel expected = model;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Model()
        {
            service.Delete(model.Id);

            Assert.Empty(context.Set<ProductModel>());
        }
    }
}
