using BankSystem.Domain;

namespace BankSystem.Application.DataTransferObjects
{
    public class TransactionDTO
    {
        public double Value { get; set; }
        public string Description { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}