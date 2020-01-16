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
    public class StateProvinceServiceTests : IDisposable
    {
        private StateProvinceService service;
        private TestingContext context;
        private StateProvince province;

        public StateProvinceServiceTests()
        {
            context = new TestingContext();
            service = new StateProvinceService(new UnitOfWork(new TestingContext(context)));

            context.Set<StateProvince>().Add(province = ObjectsFactory.CreateStateProvince());
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
            StateProvinceView actual = service.Get<StateProvinceView>(province.Id)!;
            StateProvinceView expected = Mapper.Map<StateProvinceView>(province);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsProvinceViews()
        {
            StateProvinceView[] actual = service.GetViews().ToArray();
            StateProvinceView[] expected = context
                .Set<StateProvince>()
                .ProjectTo<StateProvinceView>()
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
        public void Create_Province()
        {
            StateProvinceView view = ObjectsFactory.CreateStateProvinceView(2);

            service.Create(view);

            StateProvince actual = context.Set<StateProvince>().AsNoTracking().Single(model => model.Id != province.Id);
            StateProvinceView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Province()
        {
            StateProvinceView view = ObjectsFactory.CreateStateProvinceView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            StateProvince actual = context.Set<StateProvince>().AsNoTracking().Single();
            StateProvince expected = province;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Province()
        {
            service.Delete(province.Id);

            Assert.Empty(context.Set<StateProvince>());
        }
    }
}
