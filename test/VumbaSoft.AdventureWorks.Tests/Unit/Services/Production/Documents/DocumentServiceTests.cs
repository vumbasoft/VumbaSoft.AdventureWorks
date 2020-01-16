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
    public class DocumentServiceTests : IDisposable
    {
        private DocumentService service;
        private TestingContext context;
        private Document document;

        public DocumentServiceTests()
        {
            context = new TestingContext();
            service = new DocumentService(new UnitOfWork(new TestingContext(context)));

            context.Set<Document>().Add(document = ObjectsFactory.CreateDocument());
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
            DocumentView actual = service.Get<DocumentView>(document.Id)!;
            DocumentView expected = Mapper.Map<DocumentView>(document);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsDocumentViews()
        {
            DocumentView[] actual = service.GetViews().ToArray();
            DocumentView[] expected = context
                .Set<Document>()
                .ProjectTo<DocumentView>()
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
            DocumentView view = ObjectsFactory.CreateDocumentView(2);

            service.Create(view);

            Document actual = context.Set<Document>().AsNoTracking().Single(model => model.Id != document.Id);
            DocumentView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Document()
        {
            DocumentView view = ObjectsFactory.CreateDocumentView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            Document actual = context.Set<Document>().AsNoTracking().Single();
            Document expected = document;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Document()
        {
            service.Delete(document.Id);

            Assert.Empty(context.Set<Document>());
        }
    }
}
