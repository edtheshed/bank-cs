using System;
namespace BankKata
{
    public class Bank
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IStatementPrinter _statementPrinter;

        public Bank(ITransactionRepository transactionRepository, IStatementPrinter statementPrinter)
        {
            _transactionRepository = transactionRepository;
            _statementPrinter = statementPrinter;
        }

        public void Deposit(int amount)
        {
            _transactionRepository.SaveDeposit(amount);
        }

        public void Withdraw(int amount)
        {
            _transactionRepository.SaveWithdrawal(amount);
        }

        public void PrintStatement()
        {
            var transactions = _transactionRepository.GetTransactions();
            _statementPrinter.PrintStatement(transactions);
        }
    }
}
