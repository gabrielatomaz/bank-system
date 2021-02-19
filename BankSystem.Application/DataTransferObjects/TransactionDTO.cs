using AutoMapper;

namespace BankSystem.Application.DataTransferObjects
{
    public class TransactionDTO
    {
        public double Value { get; set; }
        public string Description { get; set; }
        public int AccountId { get; set; }
    }
}