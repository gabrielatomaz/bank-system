using System;
namespace BankSystem.Domain
{
    public class Transaction
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TransactionType TransactionType { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }

    public enum TransactionType
    {
        Payment,
        Withdraw,
        Deposit
    }
}
