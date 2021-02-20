using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BankSystem.Domain.Entities;

namespace BankSystem.Domain 
{
  public class Account : Base
  {
    public string Agency { get; set; }
    public int Number { get; set; }
    public int Digit { get; set; }
    public double Balance { get; set; }
    public User User { get; set; }
    public IEnumerable<Transaction> Trasactions { get; set; }

    public bool hasBalance(double value) 
    {
      return Balance >= value;
    }
  }
}
