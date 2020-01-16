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
    public class ProductDescriptionServiceTests : IDisposable
    {
        private ProductDescriptionService service;
        private TestingContext context;
        private ProductDescription description;

        public ProductDescriptionServiceTests()
        {
            context = new TestingContext();
            service = new ProductDescriptionService(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductDescription>().Add(description = ObjectsFactory.CreateProductDescription());
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
            ProductDescriptionView actual = service.Get<ProductDescriptionView>(description.Id)!;
            ProductDescriptionView expected = Mapper.Map<ProductDescriptionView>(description);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsDescriptionViews()
        {
            ProductDescriptionView[] actual = service.GetViews().ToArray();
            ProductDescriptionView[] expected = context
                .Set<ProductDescription>()
                .ProjectTo<ProductDescriptionView>()
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
        public void Create_Description()
        {
            ProductDescriptionView view = ObjectsFactory.CreateProductDescriptionView(2);

            service.Create(view);

            ProductDescription actual = context.Set<ProductDescription>().AsNoTracking().Single(model => model.Id != description.Id);
            ProductDescriptionView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Description()
        {
            ProductDescriptionView view = ObjectsFactory.CreateProductDescriptionView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            ProductDescription actual = context.Set<ProductDescription>().AsNoTracking().Single();
            ProductDescription expected = description;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Description()
        {
            service.Delete(description.Id);

            Assert.Empty(context.Set<ProductDescription>());
        }
    }
}
