using System.Collections.Generic;
using BankSystem.Application.DataTransferObjects;

namespace BankSystem.Application.Interfaces
{
    public interface ITransactionApplicationService
    {
        void Add(TransactionDTO transactionDTO);
        void Update(TransactionDTO transactionDTO);
        void Remove(TransactionDTO transactionDTO);
        TransactionDTO GetBy(int id);
        IEnumerable<TransactionDTO> GetAll();
    }
}