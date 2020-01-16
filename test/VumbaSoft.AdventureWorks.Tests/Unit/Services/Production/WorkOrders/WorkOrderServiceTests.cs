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
    public class WorkOrderServiceTests : IDisposable
    {
        private WorkOrderService service;
        private TestingContext context;
        private WorkOrder order;

        public WorkOrderServiceTests()
        {
            context = new TestingContext();
            service = new WorkOrderService(new UnitOfWork(new TestingContext(context)));

            context.Set<WorkOrder>().Add(order = ObjectsFactory.CreateWorkOrder());
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
            WorkOrderView actual = service.Get<WorkOrderView>(order.Id)!;
            WorkOrderView expected = Mapper.Map<WorkOrderView>(order);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsOrderViews()
        {
            WorkOrderView[] actual = service.GetViews().ToArray();
            WorkOrderView[] expected = context
                .Set<WorkOrder>()
                .ProjectTo<WorkOrderView>()
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
        public void Create_Order()
        {
            WorkOrderView view = ObjectsFactory.CreateWorkOrderView(2);

            service.Create(view);

            WorkOrder actual = context.Set<WorkOrder>().AsNoTracking().Single(model => model.Id != order.Id);
            WorkOrderView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Order()
        {
            WorkOrderView view = ObjectsFactory.CreateWorkOrderView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            WorkOrder actual = context.Set<WorkOrder>().AsNoTracking().Single();
            WorkOrder expected = order;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Order()
        {
            service.Delete(order.Id);

            Assert.Empty(context.Set<WorkOrder>());
        }
    }
}
