using System;
using BankSystem.Domain;

namespace BankSystem.Application.DataTransferObjects
{
    public class TransactionDTO
    {
        public double Value { get; set; }
        public string Description { get; set; }
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}