using System;
using System.Collections.Generic;
using System.Linq;

namespace BankKata
{
    public class StatementPrinter : IStatementPrinter
    {

        private const string StatementHeader = "Date || Amount || Balance";
        private readonly IPrinter _printer;
        private StatementFormatter _statementFormatter;

        public StatementPrinter(IPrinter printer, StatementFormatter statementFormatter)
        {
            _printer = printer;
            _statementFormatter = statementFormatter;
        }
        
        public void PrintStatement(IReadOnlyCollection<Transaction> transactions)
        {
            _printer.Print(StatementHeader);
            var total = transactions.Sum(t => t.Amount);

            for (int txIndex = transactions.Count - 1; txIndex >= 0; txIndex--)
            {
                _printer.Print($"{FormatDate(transactions.ElementAt(txIndex).DateTime)} || {transactions.ElementAt(txIndex).Amount} || {total}");
                total -= transactions.ElementAt(txIndex).Amount;
            }
        }

        private static string FormatDate(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy");
        }
    }
}