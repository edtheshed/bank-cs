using System;
using System.Diagnostics.CodeAnalysis;

namespace BankKata
{
    public class Transaction : IEquatable<Transaction>
    {
        public int Amount { get; }
        public DateTime DateTime { get; }

        public Transaction(int amount, DateTime date)
        {
            Amount = amount;
            DateTime = date;
        }

        public bool Equals(Transaction other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Amount == other.Amount && DateTime.Equals(other.DateTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Transaction) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, DateTime);
        }
    }
}
