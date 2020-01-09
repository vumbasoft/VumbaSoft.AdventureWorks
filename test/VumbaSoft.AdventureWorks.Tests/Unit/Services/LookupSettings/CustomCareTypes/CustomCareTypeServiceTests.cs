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
    public class CustomCareTypeServiceTests : IDisposable
    {
        private CustomCareTypeService service;
        private TestingContext context;
        private CustomCareType type;

        public CustomCareTypeServiceTests()
        {
            context = new TestingContext();
            service = new CustomCareTypeService(new UnitOfWork(new TestingContext(context)));

            context.Set<CustomCareType>().Add(type = ObjectsFactory.CreateCustomCareType());
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
            CustomCareTypeView actual = service.Get<CustomCareTypeView>(type.Id)!;
            CustomCareTypeView expected = Mapper.Map<CustomCareTypeView>(type);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsTypeViews()
        {
            CustomCareTypeView[] actual = service.GetViews().ToArray();
            CustomCareTypeView[] expected = context
                .Set<CustomCareType>()
                .ProjectTo<CustomCareTypeView>()
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
        public void Create_Type()
        {
            CustomCareTypeView view = ObjectsFactory.CreateCustomCareTypeView(2);

            service.Create(view);

            CustomCareType actual = context.Set<CustomCareType>().AsNoTracking().Single(model => model.Id != type.Id);
            CustomCareTypeView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Type()
        {
            CustomCareTypeView view = ObjectsFactory.CreateCustomCareTypeView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            CustomCareType actual = context.Set<CustomCareType>().AsNoTracking().Single();
            CustomCareType expected = type;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Type()
        {
            service.Delete(type.Id);

            Assert.Empty(context.Set<CustomCareType>());
        }
    }
}
