using System.Collections.Generic;
using System.Linq;

namespace BankKata
{
    public class StatementFormatter
    {
        public string FormatLine(Transaction transaction)
        {
            throw new System.NotImplementedException();
        }
        
        public static string GetStatementLine(IReadOnlyCollection<Transaction> transactions, int txIndex, int total)
        {
            return $"{transactions.ElementAt(txIndex).DateTime} || {transactions.ElementAt(txIndex).Amount} || {total}";
        }
    }
}