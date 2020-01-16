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
    public class VendorContactServiceTests : IDisposable
    {
        private VendorContactService service;
        private TestingContext context;
        private VendorContact contact;

        public VendorContactServiceTests()
        {
            context = new TestingContext();
            service = new VendorContactService(new UnitOfWork(new TestingContext(context)));

            context.Set<VendorContact>().Add(contact = ObjectsFactory.CreateVendorContact());
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
            VendorContactView actual = service.Get<VendorContactView>(contact.Id)!;
            VendorContactView expected = Mapper.Map<VendorContactView>(contact);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsContactViews()
        {
            VendorContactView[] actual = service.GetViews().ToArray();
            VendorContactView[] expected = context
                .Set<VendorContact>()
                .ProjectTo<VendorContactView>()
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
        public void Create_Contact()
        {
            VendorContactView view = ObjectsFactory.CreateVendorContactView(2);

            service.Create(view);

            VendorContact actual = context.Set<VendorContact>().AsNoTracking().Single(model => model.Id != contact.Id);
            VendorContactView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Contact()
        {
            VendorContactView view = ObjectsFactory.CreateVendorContactView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            VendorContact actual = context.Set<VendorContact>().AsNoTracking().Single();
            VendorContact expected = contact;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Contact()
        {
            service.Delete(contact.Id);

            Assert.Empty(context.Set<VendorContact>());
        }
    }
}
