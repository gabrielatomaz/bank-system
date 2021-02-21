namespace BankSystem.Application.DataTransferObjects
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public int Agency { get; set; }
        public int Number { get; set; }
        public double Balance { get; set; }
        public int UserId { get; set; }
    }
}