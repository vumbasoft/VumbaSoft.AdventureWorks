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
    public class ProductPhotoServiceTests : IDisposable
    {
        private ProductPhotoService service;
        private TestingContext context;
        private ProductPhoto photo;

        public ProductPhotoServiceTests()
        {
            context = new TestingContext();
            service = new ProductPhotoService(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductPhoto>().Add(photo = ObjectsFactory.CreateProductPhoto());
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
            ProductPhotoView actual = service.Get<ProductPhotoView>(photo.Id)!;
            ProductPhotoView expected = Mapper.Map<ProductPhotoView>(photo);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsPhotoViews()
        {
            ProductPhotoView[] actual = service.GetViews().ToArray();
            ProductPhotoView[] expected = context
                .Set<ProductPhoto>()
                .ProjectTo<ProductPhotoView>()
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
            ProductPhotoView view = ObjectsFactory.CreateProductPhotoView(2);

            service.Create(view);

            ProductPhoto actual = context.Set<ProductPhoto>().AsNoTracking().Single(model => model.Id != photo.Id);
            ProductPhotoView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Photo()
        {
            ProductPhotoView view = ObjectsFactory.CreateProductPhotoView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            ProductPhoto actual = context.Set<ProductPhoto>().AsNoTracking().Single();
            ProductPhoto expected = photo;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Photo()
        {
            service.Delete(photo.Id);

            Assert.Empty(context.Set<ProductPhoto>());
        }
    }
}
