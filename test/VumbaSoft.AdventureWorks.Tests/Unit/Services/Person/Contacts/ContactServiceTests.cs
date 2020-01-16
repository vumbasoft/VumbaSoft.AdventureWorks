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
    public class ContactServiceTests : IDisposable
    {
        private ContactService service;
        private TestingContext context;
        private Contact contact;

        public ContactServiceTests()
        {
            context = new TestingContext();
            service = new ContactService(new UnitOfWork(new TestingContext(context)));

            context.Set<Contact>().Add(contact = ObjectsFactory.CreateContact());
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
            ContactView actual = service.Get<ContactView>(contact.Id)!;
            ContactView expected = Mapper.Map<ContactView>(contact);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsContactViews()
        {
            ContactView[] actual = service.GetViews().ToArray();
            ContactView[] expected = context
                .Set<Contact>()
                .ProjectTo<ContactView>()
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
            ContactView view = ObjectsFactory.CreateContactView(2);

            service.Create(view);

            Contact actual = context.Set<Contact>().AsNoTracking().Single(model => model.Id != contact.Id);
            ContactView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Contact()
        {
            ContactView view = ObjectsFactory.CreateContactView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            Contact actual = context.Set<Contact>().AsNoTracking().Single();
            Contact expected = contact;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Contact()
        {
            service.Delete(contact.Id);

            Assert.Empty(context.Set<Contact>());
        }
    }
}
