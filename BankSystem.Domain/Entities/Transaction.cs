using System;
using System.ComponentModel.DataAnnotations.Schema;
using BankSystem.Domain.Entities;

namespace BankSystem.Domain 
{
  public class Transaction : Base
  {
    public double Value { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public TransactionType TransactionType { get; set; }
  }

  public enum TransactionType {
    Payment,
    Withdraw,
    Deposit
  }
}
