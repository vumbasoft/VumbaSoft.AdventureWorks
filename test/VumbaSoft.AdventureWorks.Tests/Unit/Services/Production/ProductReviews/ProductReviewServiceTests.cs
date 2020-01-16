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
    public class ProductReviewServiceTests : IDisposable
    {
        private ProductReviewService service;
        private TestingContext context;
        private ProductReview review;

        public ProductReviewServiceTests()
        {
            context = new TestingContext();
            service = new ProductReviewService(new UnitOfWork(new TestingContext(context)));

            context.Set<ProductReview>().Add(review = ObjectsFactory.CreateProductReview());
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
            ProductReviewView actual = service.Get<ProductReviewView>(review.Id)!;
            ProductReviewView expected = Mapper.Map<ProductReviewView>(review);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsReviewViews()
        {
            ProductReviewView[] actual = service.GetViews().ToArray();
            ProductReviewView[] expected = context
                .Set<ProductReview>()
                .ProjectTo<ProductReviewView>()
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
        public void Create_Review()
        {
            ProductReviewView view = ObjectsFactory.CreateProductReviewView(2);

            service.Create(view);

            ProductReview actual = context.Set<ProductReview>().AsNoTracking().Single(model => model.Id != review.Id);
            ProductReviewView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Review()
        {
            ProductReviewView view = ObjectsFactory.CreateProductReviewView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            ProductReview actual = context.Set<ProductReview>().AsNoTracking().Single();
            ProductReview expected = review;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Review()
        {
            service.Delete(review.Id);

            Assert.Empty(context.Set<ProductReview>());
        }
    }
}
