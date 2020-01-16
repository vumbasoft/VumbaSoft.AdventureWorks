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
    public class UnitMeasureServiceTests : IDisposable
    {
        private UnitMeasureService service;
        private TestingContext context;
        private UnitMeasure measure;

        public UnitMeasureServiceTests()
        {
            context = new TestingContext();
            service = new UnitMeasureService(new UnitOfWork(new TestingContext(context)));

            context.Set<UnitMeasure>().Add(measure = ObjectsFactory.CreateUnitMeasure());
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
            UnitMeasureView actual = service.Get<UnitMeasureView>(measure.Id)!;
            UnitMeasureView expected = Mapper.Map<UnitMeasureView>(measure);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsMeasureViews()
        {
            UnitMeasureView[] actual = service.GetViews().ToArray();
            UnitMeasureView[] expected = context
                .Set<UnitMeasure>()
                .ProjectTo<UnitMeasureView>()
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
        public void Create_Measure()
        {
            UnitMeasureView view = ObjectsFactory.CreateUnitMeasureView(2);

            service.Create(view);

            UnitMeasure actual = context.Set<UnitMeasure>().AsNoTracking().Single(model => model.Id != measure.Id);
            UnitMeasureView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Measure()
        {
            UnitMeasureView view = ObjectsFactory.CreateUnitMeasureView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            UnitMeasure actual = context.Set<UnitMeasure>().AsNoTracking().Single();
            UnitMeasure expected = measure;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Measure()
        {
            service.Delete(measure.Id);

            Assert.Empty(context.Set<UnitMeasure>());
        }
    }
}
