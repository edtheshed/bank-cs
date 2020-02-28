using System.Collections.Generic;

namespace BankKata
{
    public interface ITransactionRepository
    {
        IReadOnlyCollection<Transaction> GetTransactions();
        void SaveDeposit(int amount);
        void SaveWithdrawal(int amount);
    }
}
