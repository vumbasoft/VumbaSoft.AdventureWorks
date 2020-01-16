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
    public class SpecialOfferServiceTests : IDisposable
    {
        private SpecialOfferService service;
        private TestingContext context;
        private SpecialOffer offer;

        public SpecialOfferServiceTests()
        {
            context = new TestingContext();
            service = new SpecialOfferService(new UnitOfWork(new TestingContext(context)));

            context.Set<SpecialOffer>().Add(offer = ObjectsFactory.CreateSpecialOffer());
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
            SpecialOfferView actual = service.Get<SpecialOfferView>(offer.Id)!;
            SpecialOfferView expected = Mapper.Map<SpecialOfferView>(offer);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsOfferViews()
        {
            SpecialOfferView[] actual = service.GetViews().ToArray();
            SpecialOfferView[] expected = context
                .Set<SpecialOffer>()
                .ProjectTo<SpecialOfferView>()
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
        public void Create_Offer()
        {
            SpecialOfferView view = ObjectsFactory.CreateSpecialOfferView(2);

            service.Create(view);

            SpecialOffer actual = context.Set<SpecialOffer>().AsNoTracking().Single(model => model.Id != offer.Id);
            SpecialOfferView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Offer()
        {
            SpecialOfferView view = ObjectsFactory.CreateSpecialOfferView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            SpecialOffer actual = context.Set<SpecialOffer>().AsNoTracking().Single();
            SpecialOffer expected = offer;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Offer()
        {
            service.Delete(offer.Id);

            Assert.Empty(context.Set<SpecialOffer>());
        }
    }
}
