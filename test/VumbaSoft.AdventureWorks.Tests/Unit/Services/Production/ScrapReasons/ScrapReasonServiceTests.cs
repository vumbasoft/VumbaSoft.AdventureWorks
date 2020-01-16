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
    public class ScrapReasonServiceTests : IDisposable
    {
        private ScrapReasonService service;
        private TestingContext context;
        private ScrapReason reason;

        public ScrapReasonServiceTests()
        {
            context = new TestingContext();
            service = new ScrapReasonService(new UnitOfWork(new TestingContext(context)));

            context.Set<ScrapReason>().Add(reason = ObjectsFactory.CreateScrapReason());
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
            ScrapReasonView actual = service.Get<ScrapReasonView>(reason.Id)!;
            ScrapReasonView expected = Mapper.Map<ScrapReasonView>(reason);

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void GetViews_ReturnsReasonViews()
        {
            ScrapReasonView[] actual = service.GetViews().ToArray();
            ScrapReasonView[] expected = context
                .Set<ScrapReason>()
                .ProjectTo<ScrapReasonView>()
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
        public void Create_Reason()
        {
            ScrapReasonView view = ObjectsFactory.CreateScrapReasonView(2);

            service.Create(view);

            ScrapReason actual = context.Set<ScrapReason>().AsNoTracking().Single(model => model.Id != reason.Id);
            ScrapReasonView expected = view;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Edit_Reason()
        {
            ScrapReasonView view = ObjectsFactory.CreateScrapReasonView();

            Assert.True(false, "Above properties were not sanity checked");

            service.Edit(view);

            ScrapReason actual = context.Set<ScrapReason>().AsNoTracking().Single();
            ScrapReason expected = reason;

            Assert.True(false, "Not all properties tested");
        }

        [Fact]
        public void Delete_Reason()
        {
            service.Delete(reason.Id);

            Assert.Empty(context.Set<ScrapReason>());
        }
    }
}
