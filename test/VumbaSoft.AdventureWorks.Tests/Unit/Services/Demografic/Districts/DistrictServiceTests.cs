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
    public class DistrictServiceTests : IDisposable
    {
        private DistrictService service;
        private TestingContext context;
        private District district;

        public DistrictServiceTests()
        {
            context = new TestingContext();
            service = new DistrictService(new UnitOfWork(new TestingContext(context)));

            context.Set<District>().Add(district = ObjectsFactory.CreateDistrict());
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
            DistrictView actual = service.Get<DistrictView>(district.Id)!;
            DistrictView expected = Mapper.Map<DistrictView>(district);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsDistrictViews()
        {
            DistrictView[] actual = service.GetViews().ToArray();
            DistrictView[] expected = context
                .Set<District>()
                .ProjectTo<DistrictView>()
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
        public void Create_District()
        {
            DistrictView view = ObjectsFactory.CreateDistrictView(2);

            service.Create(view);

            District actual = context.Set<District>().AsNoTracking().Single(model => model.Id != district.Id);
            DistrictView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_District()
        {
            DistrictView view = ObjectsFactory.CreateDistrictView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            District actual = context.Set<District>().AsNoTracking().Single();
            District expected = district;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_District()
        {
            service.Delete(district.Id);

            Assert.Empty(context.Set<District>());
        }
    }
}
