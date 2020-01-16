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
    public class ProductModelProductDescriptionCultureServiceTests : IDisposable
    {
        private ProductModelProductDescriptionCultureService service;
        private TestingContext context;
        private ProductModelProductDescriptionCulture culture;

        public ProductModelProductDescriptionCultureServiceTests()
        {
            context = new TestingContext();
            service = new ProductModelProductDescriptionCultureService(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductModelProductDescriptionCulture>().Add(culture = ObjectsFactory.CreateProductModelProductDescriptionCulture());
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
            ProductModelProductDescriptionCultureView actual = service.Get<ProductModelProductDescriptionCultureView>(culture.Id)!;
            ProductModelProductDescriptionCultureView expected = Mapper.Map<ProductModelProductDescriptionCultureView>(culture);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsCultureViews()
        {
            ProductModelProductDescriptionCultureView[] actual = service.GetViews().ToArray();
            ProductModelProductDescriptionCultureView[] expected = context
                .Set<ProductModelProductDescriptionCulture>()
                .ProjectTo<ProductModelProductDescriptionCultureView>()
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
        public void Create_Culture()
        {
            ProductModelProductDescriptionCultureView view = ObjectsFactory.CreateProductModelProductDescriptionCultureView(2);

            service.Create(view);

            ProductModelProductDescriptionCulture actual = context.Set<ProductModelProductDescriptionCulture>().AsNoTracking().Single(model => model.Id != culture.Id);
            ProductModelProductDescriptionCultureView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Culture()
        {
            ProductModelProductDescriptionCultureView view = ObjectsFactory.CreateProductModelProductDescriptionCultureView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            ProductModelProductDescriptionCulture actual = context.Set<ProductModelProductDescriptionCulture>().AsNoTracking().Single();
            ProductModelProductDescriptionCulture expected = culture;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Culture()
        {
            service.Delete(culture.Id);

            Assert.Empty(context.Set<ProductModelProductDescriptionCulture>());
        }
    }
}
