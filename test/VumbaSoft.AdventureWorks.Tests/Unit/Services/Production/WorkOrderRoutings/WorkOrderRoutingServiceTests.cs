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
    public class WorkOrderRoutingServiceTests : IDisposable
    {
        private WorkOrderRoutingService service;
        private TestingContext context;
        private WorkOrderRouting routing;

        public WorkOrderRoutingServiceTests()
        {
            context = new TestingContext();
            service = new WorkOrderRoutingService(new UnitOfWork(new TestingContext(context)));

            context.Set<WorkOrderRouting>().Add(routing = ObjectsFactory.CreateWorkOrderRouting());
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
            WorkOrderRoutingView actual = service.Get<WorkOrderRoutingView>(routing.Id)!;
            WorkOrderRoutingView expected = Mapper.Map<WorkOrderRoutingView>(routing);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsRoutingViews()
        {
            WorkOrderRoutingView[] actual = service.GetViews().ToArray();
            WorkOrderRoutingView[] expected = context
                .Set<WorkOrderRouting>()
                .ProjectTo<WorkOrderRoutingView>()
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
        public void Create_Routing()
        {
            WorkOrderRoutingView view = ObjectsFactory.CreateWorkOrderRoutingView(2);

            service.Create(view);

            WorkOrderRouting actual = context.Set<WorkOrderRouting>().AsNoTracking().Single(model => model.Id != routing.Id);
            WorkOrderRoutingView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Routing()
        {
            WorkOrderRoutingView view = ObjectsFactory.CreateWorkOrderRoutingView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            WorkOrderRouting actual = context.Set<WorkOrderRouting>().AsNoTracking().Single();
            WorkOrderRouting expected = routing;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Routing()
        {
            service.Delete(routing.Id);

            Assert.Empty(context.Set<WorkOrderRouting>());
        }
    }
}
