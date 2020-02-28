using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BankKata
{
    public class TransactionRepository : ITransactionRepository
    {
        private List<Transaction> transactions;
        private Clock _clock;

        public TransactionRepository(Clock clock)
        {
            transactions = new List<Transaction>();
            _clock = clock;
        }

        public IReadOnlyCollection<Transaction> GetTransactions()
        {
            return new ReadOnlyCollection<Transaction>(transactions);
        }

        public void SaveDeposit(int amount)
        {
            transactions.Add(new Transaction(amount, _clock.GetTime()));
        }

        public void SaveWithdrawal(int amount)
        {
            transactions.Add(new Transaction(-amount, _clock.GetTime()));
        }
    }
}