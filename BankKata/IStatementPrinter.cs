using System.Collections.Generic;

namespace BankKata
{
    public interface IStatementPrinter
    {
        void PrintStatement(IReadOnlyCollection<Transaction> transactions);
    }
}