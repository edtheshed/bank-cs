using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Moq;
using Xunit;

namespace BankKata.test
{
    public class BankAccountShould
    {
        private readonly Mock<ITransactionRepository> _mockRepo;
        private readonly Bank _bank;
        private readonly Mock<IStatementPrinter> _mockStatementPrinter;

        public BankAccountShould()
        {
            _mockRepo = new Mock<ITransactionRepository>();
            _mockStatementPrinter = new Mock<IStatementPrinter>();
            _bank = new Bank(_mockRepo.Object, _mockStatementPrinter.Object);
        }

        [Fact]
        public void AcceptADeposit()
        {
            _bank.Deposit(100);

            _mockRepo.Verify(r => r.SaveDeposit(100), Times.Once);
        }

        [Fact]
        public void AcceptAWithdraw()
        {
            _bank.Withdraw(100);

            _mockRepo.Verify(r => r.SaveWithdrawal(100), Times.Once);
        }

        [Fact]
        public void PrintAStatementWithATransaction()
        {
            var transactionList = new List<Transaction>{new Transaction(100, DateTime.Now)};
            var readonlyList = new ReadOnlyCollection<Transaction>(transactionList);
            _mockRepo.Setup(r => r.GetTransactions()).Returns(transactionList);
                
            _bank.PrintStatement();
            
            _mockStatementPrinter.Verify(sp => sp.PrintStatement(readonlyList), Times.Once);
        }
    }
}