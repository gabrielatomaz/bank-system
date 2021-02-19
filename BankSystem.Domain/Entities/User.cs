using BankSystem.Domain.Entities;

namespace BankSystem.Domain 
{
  public class User : Base
  {
    public string Name { get; set; }
    public Account Account { get; set; }
  }
}
