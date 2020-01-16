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
    public class BillOfMaterialServiceTests : IDisposable
    {
        private BillOfMaterialService service;
        private TestingContext context;
        private BillOfMaterial material;

        public BillOfMaterialServiceTests()
        {
            context = new TestingContext();
            service = new BillOfMaterialService(new UnitOfWork(new TestingContext(context)));

            context.Set<BillOfMaterial>().Add(material = ObjectsFactory.CreateBillOfMaterial());
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
            BillOfMaterialView actual = service.Get<BillOfMaterialView>(material.Id)!;
            BillOfMaterialView expected = Mapper.Map<BillOfMaterialView>(material);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsMaterialViews()
        {
            BillOfMaterialView[] actual = service.GetViews().ToArray();
            BillOfMaterialView[] expected = context
                .Set<BillOfMaterial>()
                .ProjectTo<BillOfMaterialView>()
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
        public void Create_Material()
        {
            BillOfMaterialView view = ObjectsFactory.CreateBillOfMaterialView(2);

            service.Create(view);

            BillOfMaterial actual = context.Set<BillOfMaterial>().AsNoTracking().Single(model => model.Id != material.Id);
            BillOfMaterialView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Material()
        {
            BillOfMaterialView view = ObjectsFactory.CreateBillOfMaterialView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            BillOfMaterial actual = context.Set<BillOfMaterial>().AsNoTracking().Single();
            BillOfMaterial expected = material;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Material()
        {
            service.Delete(material.Id);

            Assert.Empty(context.Set<BillOfMaterial>());
        }
    }
}
