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
    public class CultureServiceTests : IDisposable
    {
        private CultureService service;
        private TestingContext context;
        private Culture culture;

        public CultureServiceTests()
        {
            context = new TestingContext();
            service = new CultureService(new UnitOfWork(new TestingContext(context)));

            context.Set<Culture>().Add(culture = ObjectsFactory.CreateCulture());
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
            CultureView actual = service.Get<CultureView>(culture.Id)!;
            CultureView expected = Mapper.Map<CultureView>(culture);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsCultureViews()
        {
            CultureView[] actual = service.GetViews().ToArray();
            CultureView[] expected = context
                .Set<Culture>()
                .ProjectTo<CultureView>()
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
            CultureView view = ObjectsFactory.CreateCultureView(2);

            service.Create(view);

            Culture actual = context.Set<Culture>().AsNoTracking().Single(model => model.Id != culture.Id);
            CultureView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Culture()
        {
            CultureView view = ObjectsFactory.CreateCultureView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            Culture actual = context.Set<Culture>().AsNoTracking().Single();
            Culture expected = culture;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Culture()
        {
            service.Delete(culture.Id);

            Assert.Empty(context.Set<Culture>());
        }
    }
}
