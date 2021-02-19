using System;
using BankSystem.Domain.Entities;

namespace BankSystem.Domain 
{
  public class Transaction : Base
  {
    public TransactionType TransactionType { get; set; }
    public double Value { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public Account Account { get; set; }
  }

  public enum TransactionType {
    Payment,
    Withdraw,
    Deposit
  }
}
