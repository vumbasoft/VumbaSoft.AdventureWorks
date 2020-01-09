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
    public class AdventureworkFacilityServiceTests : IDisposable
    {
        private AdventureworkFacilityService service;
        private TestingContext context;
        private AdventureworkFacility facility;

        public AdventureworkFacilityServiceTests()
        {
            context = new TestingContext();
            service = new AdventureworkFacilityService(new UnitOfWork(new TestingContext(context)));

            context.Set<AdventureworkFacility>().Add(facility = ObjectsFactory.CreateAdventureworkFacility());
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
            AdventureworkFacilityView actual = service.Get<AdventureworkFacilityView>(facility.Id)!;
            AdventureworkFacilityView expected = Mapper.Map<AdventureworkFacilityView>(facility);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsFacilityViews()
        {
            AdventureworkFacilityView[] actual = service.GetViews().ToArray();
            AdventureworkFacilityView[] expected = context
                .Set<AdventureworkFacility>()
                .ProjectTo<AdventureworkFacilityView>()
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
        public void Create_Facility()
        {
            AdventureworkFacilityView view = ObjectsFactory.CreateAdventureworkFacilityView(2);

            service.Create(view);

            AdventureworkFacility actual = context.Set<AdventureworkFacility>().AsNoTracking().Single(model => model.Id != facility.Id);
            AdventureworkFacilityView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Facility()
        {
            AdventureworkFacilityView view = ObjectsFactory.CreateAdventureworkFacilityView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            AdventureworkFacility actual = context.Set<AdventureworkFacility>().AsNoTracking().Single();
            AdventureworkFacility expected = facility;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Facility()
        {
            service.Delete(facility.Id);

            Assert.Empty(context.Set<AdventureworkFacility>());
        }
    }
}
