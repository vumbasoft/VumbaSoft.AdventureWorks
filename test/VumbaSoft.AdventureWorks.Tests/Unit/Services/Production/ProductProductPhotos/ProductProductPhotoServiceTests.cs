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
    public class ProductProductPhotoServiceTests : IDisposable
    {
        private ProductProductPhotoService service;
        private TestingContext context;
        private ProductProductPhoto photo;

        public ProductProductPhotoServiceTests()
        {
            context = new TestingContext();
            service = new ProductProductPhotoService(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductProductPhoto>().Add(photo = ObjectsFactory.CreateProductProductPhoto());
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
            ProductProductPhotoView actual = service.Get<ProductProductPhotoView>(photo.Id)!;
            ProductProductPhotoView expected = Mapper.Map<ProductProductPhotoView>(photo);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsPhotoViews()
        {
            ProductProductPhotoView[] actual = service.GetViews().ToArray();
            ProductProductPhotoView[] expected = context
                .Set<ProductProductPhoto>()
                .ProjectTo<ProductProductPhotoView>()
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
        public void Create_Photo()
        {
            ProductProductPhotoView view = ObjectsFactory.CreateProductProductPhotoView(2);

            service.Create(view);

            ProductProductPhoto actual = context.Set<ProductProductPhoto>().AsNoTracking().Single(model => model.Id != photo.Id);
            ProductProductPhotoView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Photo()
        {
            ProductProductPhotoView view = ObjectsFactory.CreateProductProductPhotoView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            ProductProductPhoto actual = context.Set<ProductProductPhoto>().AsNoTracking().Single();
            ProductProductPhoto expected = photo;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Photo()
        {
            service.Delete(photo.Id);

            Assert.Empty(context.Set<ProductProductPhoto>());
        }
    }
}
