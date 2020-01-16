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
    public class ProductDocumentServiceTests : IDisposable
    {
        private ProductDocumentService service;
        private TestingContext context;
        private ProductDocument document;

        public ProductDocumentServiceTests()
        {
            context = new TestingContext();
            service = new ProductDocumentService(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductDocument>().Add(document = ObjectsFactory.CreateProductDocument());
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
            ProductDocumentView actual = service.Get<ProductDocumentView>(document.Id)!;
            ProductDocumentView expected = Mapper.Map<ProductDocumentView>(document);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsDocumentViews()
        {
            ProductDocumentView[] actual = service.GetViews().ToArray();
            ProductDocumentView[] expected = context
                .Set<ProductDocument>()
                .ProjectTo<ProductDocumentView>()
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
        public void Create_Document()
        {
            ProductDocumentView view = ObjectsFactory.CreateProductDocumentView(2);

            service.Create(view);

            ProductDocument actual = context.Set<ProductDocument>().AsNoTracking().Single(model => model.Id != document.Id);
            ProductDocumentView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Document()
        {
            ProductDocumentView view = ObjectsFactory.CreateProductDocumentView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            ProductDocument actual = context.Set<ProductDocument>().AsNoTracking().Single();
            ProductDocument expected = document;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Document()
        {
            service.Delete(document.Id);

            Assert.Empty(context.Set<ProductDocument>());
        }
    }
}
