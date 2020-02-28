using System;
using System.Collections;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace BankKata.test
{
    public class BankAccountAcceptanceTest
    {
        private const string StatementHeader = "Date || Amount || Balance";
        readonly Mock<IPrinter> _mockPrinter;
        private readonly Mock<Clock> _mockClock;
        private ITransactionRepository _transactionRepo;
        private readonly StatementPrinter _statementPrinter;

        public BankAccountAcceptanceTest()
        {
            _mockPrinter = new Mock<IPrinter>(MockBehavior.Strict);
            _mockClock = new Mock<Clock>();
            var statementFormatter = new StatementFormatter();
            _statementPrinter = new StatementPrinter(_mockPrinter.Object, statementFormatter);
        }


        [Fact]
        public void BankAccountShouldPrintAStatementWithTransactionsInReverseChronologicalOrder()
        {
            var results = new Queue<DateTime>(new [] {new DateTime(2012, 1, 10),
                new DateTime(2012, 1, 13),
                new DateTime(2012, 1, 14)});
            
            _mockClock.Setup(c => c.GetTime()).Returns(results.Dequeue);
            _mockPrinter.SetupAllProperties();
            
            var sequence = new MockSequence();
            _mockPrinter.InSequence(sequence).Setup(p => p.Print(StatementHeader));
            _mockPrinter.InSequence(sequence).Setup(p => p.Print("14/01/2012 || -500 || 2500"));
            _mockPrinter.InSequence(sequence).Setup(p => p.Print("13/01/2012 || 2000 || 3000"));
            _mockPrinter.InSequence(sequence).Setup(p => p.Print("10/01/2012 || 1000 || 1000"));
            
            _transactionRepo = new TransactionRepository(_mockClock.Object);
            var bank = new Bank(_transactionRepo, _statementPrinter);

            bank.Deposit(1000);
            bank.Deposit(2000);
            bank.Withdraw(500);

            bank.PrintStatement();
            
            _mockPrinter.Verify(p => p.Print(StatementHeader));
            _mockPrinter.Verify(p => p.Print("14/01/2012 || -500 || 2500"));
            _mockPrinter.Verify(p => p.Print("13/01/2012 || 2000 || 3000"));
            _mockPrinter.Verify(p => p.Print("10/01/2012 || 1000 || 1000"));
        }
    }
}