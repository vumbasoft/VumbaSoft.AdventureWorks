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
    public class AddresstypeServiceTests : IDisposable
    {
        private AddresstypeService service;
        private TestingContext context;
        private Addresstype addresstype;

        public AddresstypeServiceTests()
        {
            context = new TestingContext();
            service = new AddresstypeService(new UnitOfWork(new TestingContext(context)));

            context.Set<Addresstype>().Add(addresstype = ObjectsFactory.CreateAddresstype());
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
            AddresstypeView actual = service.Get<AddresstypeView>(addresstype.Id)!;
            AddresstypeView expected = Mapper.Map<AddresstypeView>(addresstype);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsAddresstypeViews()
        {
            AddresstypeView[] actual = service.GetViews().ToArray();
            AddresstypeView[] expected = context
                .Set<Addresstype>()
                .ProjectTo<AddresstypeView>()
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
        public void Create_Addresstype()
        {
            AddresstypeView view = ObjectsFactory.CreateAddresstypeView(2);

            service.Create(view);

            Addresstype actual = context.Set<Addresstype>().AsNoTracking().Single(model => model.Id != addresstype.Id);
            AddresstypeView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Addresstype()
        {
            AddresstypeView view = ObjectsFactory.CreateAddresstypeView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            Addresstype actual = context.Set<Addresstype>().AsNoTracking().Single();
            Addresstype expected = addresstype;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Addresstype()
        {
            service.Delete(addresstype.Id);

            Assert.Empty(context.Set<Addresstype>());
        }
    }
}
