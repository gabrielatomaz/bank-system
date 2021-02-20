using System.ComponentModel.DataAnnotations.Schema;
using BankSystem.Domain.Entities;

namespace BankSystem.Domain 
{
  public class User : Base
  {
    public string Name { get; set; }
  }
}
