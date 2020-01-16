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
    public class SpecialOfferProductServiceTests : IDisposable
    {
        private SpecialOfferProductService service;
        private TestingContext context;
        private SpecialOfferProduct product;

        public SpecialOfferProductServiceTests()
        {
            context = new TestingContext();
            service = new SpecialOfferProductService(new UnitOfWork(new TestingContext(context)));

            context.Set<SpecialOfferProduct>().Add(product = ObjectsFactory.CreateSpecialOfferProduct());
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
            SpecialOfferProductView actual = service.Get<SpecialOfferProductView>(product.Id)!;
            SpecialOfferProductView expected = Mapper.Map<SpecialOfferProductView>(product);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsProductViews()
        {
            SpecialOfferProductView[] actual = service.GetViews().ToArray();
            SpecialOfferProductView[] expected = context
                .Set<SpecialOfferProduct>()
                .ProjectTo<SpecialOfferProductView>()
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
        public void Create_Product()
        {
            SpecialOfferProductView view = ObjectsFactory.CreateSpecialOfferProductView(2);

            service.Create(view);

            SpecialOfferProduct actual = context.Set<SpecialOfferProduct>().AsNoTracking().Single(model => model.Id != product.Id);
            SpecialOfferProductView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Product()
        {
            SpecialOfferProductView view = ObjectsFactory.CreateSpecialOfferProductView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            SpecialOfferProduct actual = context.Set<SpecialOfferProduct>().AsNoTracking().Single();
            SpecialOfferProduct expected = product;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Product()
        {
            service.Delete(product.Id);

            Assert.Empty(context.Set<SpecialOfferProduct>());
        }
    }
}
