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
    public class ContactCreditCardServiceTests : IDisposable
    {
        private ContactCreditCardService service;
        private TestingContext context;
        private ContactCreditCard card;

        public ContactCreditCardServiceTests()
        {
            context = new TestingContext();
            service = new ContactCreditCardService(new UnitOfWork(new TestingContext(context)));

            context.Set<ContactCreditCard>().Add(card = ObjectsFactory.CreateContactCreditCard());
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
            ContactCreditCardView actual = service.Get<ContactCreditCardView>(card.Id)!;
            ContactCreditCardView expected = Mapper.Map<ContactCreditCardView>(card);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsCardViews()
        {
            ContactCreditCardView[] actual = service.GetViews().ToArray();
            ContactCreditCardView[] expected = context
                .Set<ContactCreditCard>()
                .ProjectTo<ContactCreditCardView>()
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
        public void Create_Card()
        {
            ContactCreditCardView view = ObjectsFactory.CreateContactCreditCardView(2);

            service.Create(view);

            ContactCreditCard actual = context.Set<ContactCreditCard>().AsNoTracking().Single(model => model.Id != card.Id);
            ContactCreditCardView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Card()
        {
            ContactCreditCardView view = ObjectsFactory.CreateContactCreditCardView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            ContactCreditCard actual = context.Set<ContactCreditCard>().AsNoTracking().Single();
            ContactCreditCard expected = card;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Card()
        {
            service.Delete(card.Id);

            Assert.Empty(context.Set<ContactCreditCard>());
        }
    }
}
