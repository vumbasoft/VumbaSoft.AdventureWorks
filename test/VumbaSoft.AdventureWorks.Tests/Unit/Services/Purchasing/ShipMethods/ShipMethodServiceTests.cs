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
    public class ShipMethodServiceTests : IDisposable
    {
        private ShipMethodService service;
        private TestingContext context;
        private ShipMethod method;

        public ShipMethodServiceTests()
        {
            context = new TestingContext();
            service = new ShipMethodService(new UnitOfWork(new TestingContext(context)));

            context.Set<ShipMethod>().Add(method = ObjectsFactory.CreateShipMethod());
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
            ShipMethodView actual = service.Get<ShipMethodView>(method.Id)!;
            ShipMethodView expected = Mapper.Map<ShipMethodView>(method);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsMethodViews()
        {
            ShipMethodView[] actual = service.GetViews().ToArray();
            ShipMethodView[] expected = context
                .Set<ShipMethod>()
                .ProjectTo<ShipMethodView>()
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
        public void Create_Method()
        {
            ShipMethodView view = ObjectsFactory.CreateShipMethodView(2);

            service.Create(view);

            ShipMethod actual = context.Set<ShipMethod>().AsNoTracking().Single(model => model.Id != method.Id);
            ShipMethodView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Method()
        {
            ShipMethodView view = ObjectsFactory.CreateShipMethodView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            ShipMethod actual = context.Set<ShipMethod>().AsNoTracking().Single();
            ShipMethod expected = method;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Method()
        {
            service.Delete(method.Id);

            Assert.Empty(context.Set<ShipMethod>());
        }
    }
}
