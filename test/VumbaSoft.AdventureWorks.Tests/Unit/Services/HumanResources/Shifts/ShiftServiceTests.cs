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
    public class ShiftServiceTests : IDisposable
    {
        private ShiftService service;
        private TestingContext context;
        private Shift shift;

        public ShiftServiceTests()
        {
            context = new TestingContext();
            service = new ShiftService(new UnitOfWork(new TestingContext(context)));

            context.Set<Shift>().Add(shift = ObjectsFactory.CreateShift());
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
            ShiftView actual = service.Get<ShiftView>(shift.Id)!;
            ShiftView expected = Mapper.Map<ShiftView>(shift);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsShiftViews()
        {
            ShiftView[] actual = service.GetViews().ToArray();
            ShiftView[] expected = context
                .Set<Shift>()
                .ProjectTo<ShiftView>()
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
        public void Create_Shift()
        {
            ShiftView view = ObjectsFactory.CreateShiftView(2);

            service.Create(view);

            Shift actual = context.Set<Shift>().AsNoTracking().Single(model => model.Id != shift.Id);
            ShiftView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Shift()
        {
            ShiftView view = ObjectsFactory.CreateShiftView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            Shift actual = context.Set<Shift>().AsNoTracking().Single();
            Shift expected = shift;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Shift()
        {
            service.Delete(shift.Id);

            Assert.Empty(context.Set<Shift>());
        }
    }
}
