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
    public virtual User User { get; set; }
    public int UserId { get; set; }

    public bool hasBalance(double value) 
    {
      return Balance >= value;
    }
  }
}
