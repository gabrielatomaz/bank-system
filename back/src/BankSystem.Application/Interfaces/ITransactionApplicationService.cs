using System.Collections.Generic;
using BankSystem.Application.DataTransferObjects;

namespace BankSystem.Application.Interfaces
{
    public interface ITransactionApplicationService
    {
        void Add(TransactionDTO transactionDTO);
        void Update(int id, TransactionDTO transactionDTO);
        void Remove(int id);
        TransactionDTO GetBy(int id);
        IEnumerable<TransactionDTO> GetAll();
        void Deposit(TransactionDTO transactionDTO);
        void Withdraw(TransactionDTO transactionDTO);
        void Payment(TransactionDTO transactionDTO);
    }
}