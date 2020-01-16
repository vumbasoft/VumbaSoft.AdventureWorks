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
    public class IllustrationServiceTests : IDisposable
    {
        private IllustrationService service;
        private TestingContext context;
        private Illustration illustration;

        public IllustrationServiceTests()
        {
            context = new TestingContext();
            service = new IllustrationService(new UnitOfWork(new TestingContext(context)));

            context.Set<Illustration>().Add(illustration = ObjectsFactory.CreateIllustration());
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
            IllustrationView actual = service.Get<IllustrationView>(illustration.Id)!;
            IllustrationView expected = Mapper.Map<IllustrationView>(illustration);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsIllustrationViews()
        {
            IllustrationView[] actual = service.GetViews().ToArray();
            IllustrationView[] expected = context
                .Set<Illustration>()
                .ProjectTo<IllustrationView>()
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
            IllustrationView view = ObjectsFactory.CreateIllustrationView(2);

            service.Create(view);

            Illustration actual = context.Set<Illustration>().AsNoTracking().Single(model => model.Id != illustration.Id);
            IllustrationView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Illustration()
        {
            IllustrationView view = ObjectsFactory.CreateIllustrationView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            Illustration actual = context.Set<Illustration>().AsNoTracking().Single();
            Illustration expected = illustration;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Illustration()
        {
            service.Delete(illustration.Id);

            Assert.Empty(context.Set<Illustration>());
        }
    }
}
