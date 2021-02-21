namespace BankSystem.Domain 
{
  public class User
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual Account Account { get; set; }
  }
}
