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
    public class CreditCardServiceTests : IDisposable
    {
        private CreditCardService service;
        private TestingContext context;
        private CreditCard card;

        public CreditCardServiceTests()
        {
            context = new TestingContext();
            service = new CreditCardService(new UnitOfWork(new TestingContext(context)));

            context.Set<CreditCard>().Add(card = ObjectsFactory.CreateCreditCard());
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
            CreditCardView actual = service.Get<CreditCardView>(card.Id)!;
            CreditCardView expected = Mapper.Map<CreditCardView>(card);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsCardViews()
        {
            CreditCardView[] actual = service.GetViews().ToArray();
            CreditCardView[] expected = context
                .Set<CreditCard>()
                .ProjectTo<CreditCardView>()
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
            CreditCardView view = ObjectsFactory.CreateCreditCardView(2);

            service.Create(view);

            CreditCard actual = context.Set<CreditCard>().AsNoTracking().Single(model => model.Id != card.Id);
            CreditCardView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Card()
        {
            CreditCardView view = ObjectsFactory.CreateCreditCardView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            CreditCard actual = context.Set<CreditCard>().AsNoTracking().Single();
            CreditCard expected = card;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Card()
        {
            service.Delete(card.Id);

            Assert.Empty(context.Set<CreditCard>());
        }
    }
}
