using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Tests;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class TransactionHistoryValidatorTests : IDisposable
    {
        private TransactionHistoryValidator validator;
        private TestingContext context;
        private TransactionHistory history;

        public TransactionHistoryValidatorTests()
        {
            context = new TestingContext();
            validator = new TransactionHistoryValidator(new UnitOfWork(new TestingContext(context)));

            context.Set<TransactionHistory>().Add(history = ObjectsFactory.CreateTransactionHistory());
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

            Assert.False(validator.CanCreate(ObjectsFactory.CreateTransactionHistoryView(2)));
        }

        [Fact]
        public void CanCreate_ValidHistory()
        {
            Assert.True(validator.CanCreate(ObjectsFactory.CreateTransactionHistoryView(2)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectsFactory.CreateTransactionHistoryView()));
        }

        [Fact]
        public void CanEdit_ValidHistory()
        {
            Assert.True(validator.CanEdit(ObjectsFactory.CreateTransactionHistoryView()));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }
    }
}
