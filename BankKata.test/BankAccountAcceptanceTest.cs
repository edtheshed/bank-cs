using System;
using Xunit;
using BankKata;
using Moq;

namespace BankKata.test
{
    public class BankAccountAcceptanceTest
    {

        Mock printer;
        object mockPrinter;

        public BankAccountAcceptanceTest()
        {
            printer = new Mock<Printer>();
            mockPrinter = printer.Object;
        }


        [Fact]
        public void BankAccountShouldPrintAStatementWithTransactionsInReverseChronologicalOrder()
        {
            var bank = new Bank();

            bank.deposit(1000);
            bank.deposit(2000);
            bank.withdraw(500);

            bank.printStatement();

            ting.
        }
    }
}
