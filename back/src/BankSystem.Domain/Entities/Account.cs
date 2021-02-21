using System.Collections.Generic;

namespace BankSystem.Domain 
{
  public class Account
  {
    public int Id { get; set; }
    public int Agency { get; set; }
    public int Number { get; set; }
    public double Balance { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public virtual IEnumerable<Transaction> Transactions { get; set; }

    public bool hasBalance(double value) 
    {
      return Balance >= value;
    }
  }
}
