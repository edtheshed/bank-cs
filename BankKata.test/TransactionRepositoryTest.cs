using System;
using System.Linq;
using Moq;
using Xunit;

namespace BankKata.test
{
    public class TransactionRepositoryTest
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly Mock<Clock> _mockClock;

        public TransactionRepositoryTest()
        {
            _mockClock = new Mock<Clock>();
            _transactionRepository = new TransactionRepository(_mockClock.Object);
        }

        [Fact]
        public void StoreAndRetrieveADeposit()
        {
            var amount = 100;
            var date = DateTime.Now;
            var tx = new Transaction(amount, date);
            _mockClock.Setup(c => c.GetTime()).Returns(date);
            _transactionRepository.SaveDeposit(amount);

            Assert.Equal(tx, _transactionRepository.GetTransactions().First());
        }
    }

}
