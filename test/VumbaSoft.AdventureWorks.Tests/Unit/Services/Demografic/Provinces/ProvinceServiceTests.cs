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
    public class ProvinceServiceTests : IDisposable
    {
        private ProvinceService service;
        private TestingContext context;
        private Province province;

        public ProvinceServiceTests()
        {
            context = new TestingContext();
            service = new ProvinceService(new UnitOfWork(new TestingContext(context)));

            context.Set<Province>().Add(province = ObjectsFactory.CreateProvince());
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
            ProvinceView actual = service.Get<ProvinceView>(province.Id)!;
            ProvinceView expected = Mapper.Map<ProvinceView>(province);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsProvinceViews()
        {
            ProvinceView[] actual = service.GetViews().ToArray();
            ProvinceView[] expected = context
                .Set<Province>()
                .ProjectTo<ProvinceView>()
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
            ProvinceView view = ObjectsFactory.CreateProvinceView(2);

            service.Create(view);

            Province actual = context.Set<Province>().AsNoTracking().Single(model => model.Id != province.Id);
            ProvinceView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Province()
        {
            ProvinceView view = ObjectsFactory.CreateProvinceView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            Province actual = context.Set<Province>().AsNoTracking().Single();
            Province expected = province;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Province()
        {
            service.Delete(province.Id);

            Assert.Empty(context.Set<Province>());
        }
    }
}
