namespace BankSystem.Application.DataTransferObjects
{
    public class AccountDTO
    {
        public string Agency { get; set; }
        public int Number { get; set; }
        public int Digit { get; set; }
        public double Balance { get; set; }
        public int UserId { get; set; }
    }
}