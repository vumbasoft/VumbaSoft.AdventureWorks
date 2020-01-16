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
    public class ProductModelIllustrationServiceTests : IDisposable
    {
        private ProductModelIllustrationService service;
        private TestingContext context;
        private ProductModelIllustration illustration;

        public ProductModelIllustrationServiceTests()
        {
            context = new TestingContext();
            service = new ProductModelIllustrationService(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductModelIllustration>().Add(illustration = ObjectsFactory.CreateProductModelIllustration());
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
            ProductModelIllustrationView actual = service.Get<ProductModelIllustrationView>(illustration.Id)!;
            ProductModelIllustrationView expected = Mapper.Map<ProductModelIllustrationView>(illustration);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsIllustrationViews()
        {
            ProductModelIllustrationView[] actual = service.GetViews().ToArray();
            ProductModelIllustrationView[] expected = context
                .Set<ProductModelIllustration>()
                .ProjectTo<ProductModelIllustrationView>()
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
        public void Create_Illustration()
        {
            ProductModelIllustrationView view = ObjectsFactory.CreateProductModelIllustrationView(2);

            service.Create(view);

            ProductModelIllustration actual = context.Set<ProductModelIllustration>().AsNoTracking().Single(model => model.Id != illustration.Id);
            ProductModelIllustrationView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Illustration()
        {
            ProductModelIllustrationView view = ObjectsFactory.CreateProductModelIllustrationView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            ProductModelIllustration actual = context.Set<ProductModelIllustration>().AsNoTracking().Single();
            ProductModelIllustration expected = illustration;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Illustration()
        {
            service.Delete(illustration.Id);

            Assert.Empty(context.Set<ProductModelIllustration>());
        }
    }
}
