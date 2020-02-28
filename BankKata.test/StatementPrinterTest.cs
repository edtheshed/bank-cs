using System.Collections.Generic;
using System.Collections.ObjectModel;
using Moq;
using Xunit;

namespace BankKata.test
{
    public class StatementPrinterTest
    {
        private const string StatementHeader = "Date || Amount || Balance";
        private readonly StatementPrinter _printer;
        private readonly Mock<IPrinter> _mockConsole;
        private readonly Mock<StatementFormatter> _mockFormatter;

        public StatementPrinterTest()
        {
            _mockConsole = new Mock<IPrinter>();
            _mockFormatter = new Mock<StatementFormatter>();
            _printer = new StatementPrinter(_mockConsole.Object, _mockFormatter.Object);
        }

        [Fact]
        public void ShouldPrintAStatementWithAHeader()
        {
            _printer.PrintStatement(new ReadOnlyCollection<Transaction>(new List<Transaction>()));
            
            _mockConsole.Verify(c => c.Print(StatementHeader), Times.Once);
        }
    }
}