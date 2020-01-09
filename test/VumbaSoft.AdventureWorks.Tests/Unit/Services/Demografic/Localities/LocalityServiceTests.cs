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
    public class LocalityServiceTests : IDisposable
    {
        private LocalityService service;
        private TestingContext context;
        private Locality locality;

        public LocalityServiceTests()
        {
            context = new TestingContext();
            service = new LocalityService(new UnitOfWork(new TestingContext(context)));

            context.Set<Locality>().Add(locality = ObjectsFactory.CreateLocality());
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
            LocalityView actual = service.Get<LocalityView>(locality.Id)!;
            LocalityView expected = Mapper.Map<LocalityView>(locality);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsLocalityViews()
        {
            LocalityView[] actual = service.GetViews().ToArray();
            LocalityView[] expected = context
                .Set<Locality>()
                .ProjectTo<LocalityView>()
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
        public void Create_Locality()
        {
            LocalityView view = ObjectsFactory.CreateLocalityView(2);

            service.Create(view);

            Locality actual = context.Set<Locality>().AsNoTracking().Single(model => model.Id != locality.Id);
            LocalityView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Locality()
        {
            LocalityView view = ObjectsFactory.CreateLocalityView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            Locality actual = context.Set<Locality>().AsNoTracking().Single();
            Locality expected = locality;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Locality()
        {
            service.Delete(locality.Id);

            Assert.Empty(context.Set<Locality>());
        }
    }
}
