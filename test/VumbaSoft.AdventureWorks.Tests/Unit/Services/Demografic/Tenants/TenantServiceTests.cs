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
    public class TenantServiceTests : IDisposable
    {
        private TenantService service;
        private TestingContext context;
        private Tenant tenant;

        public TenantServiceTests()
        {
            context = new TestingContext();
            service = new TenantService(new UnitOfWork(new TestingContext(context)));

            context.Set<Tenant>().Add(tenant = ObjectsFactory.CreateTenant());
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
            TenantView actual = service.Get<TenantView>(tenant.Id)!;
            TenantView expected = Mapper.Map<TenantView>(tenant);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsTenantViews()
        {
            TenantView[] actual = service.GetViews().ToArray();
            TenantView[] expected = context
                .Set<Tenant>()
                .ProjectTo<TenantView>()
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
        public void Create_Tenant()
        {
            TenantView view = ObjectsFactory.CreateTenantView(2);

            service.Create(view);

            Tenant actual = context.Set<Tenant>().AsNoTracking().Single(model => model.Id != tenant.Id);
            TenantView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Tenant()
        {
            TenantView view = ObjectsFactory.CreateTenantView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            Tenant actual = context.Set<Tenant>().AsNoTracking().Single();
            Tenant expected = tenant;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Tenant()
        {
            service.Delete(tenant.Id);

            Assert.Empty(context.Set<Tenant>());
        }
    }
}
