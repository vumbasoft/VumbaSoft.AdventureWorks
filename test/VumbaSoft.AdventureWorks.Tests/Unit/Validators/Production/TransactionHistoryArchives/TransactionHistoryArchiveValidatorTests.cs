using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class TransactionHistoryArchiveValidatorTests : IDisposable
    {
        private TransactionHistoryArchiveValidator validator;
        private TestingContext context;
        private TransactionHistoryArchive archive;

        public TransactionHistoryArchiveValidatorTests()
        {
            context = new TestingContext();
            validator = new TransactionHistoryArchiveValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<TransactionHistoryArchive>().Add(archive = ObjectsFactory.CreateTransactionHistoryArchive());
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
            validator.Dispose();
        }

        [Fact]
        public void CanCreate_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanCreate(ObjectsFactory.CreateTransactionHistoryArchiveView(2)));
        }

        [Fact]
        public void CanCreate_ValidArchive()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateTransactionHistoryArchiveView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateTransactionHistoryArchiveView()));
        }

        [Fact]
        public void CanEdit_ValidArchive()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateTransactionHistoryArchiveView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
