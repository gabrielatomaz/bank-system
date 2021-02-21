using System.Collections.Generic;

namespace BankSystem.Domain.Core.Interfaces.Services
{
    public interface ITransactionService : IBaseService<Transaction>
    {
        IEnumerable<Transaction> GetByAccountId(int accountId);

        void Deposit(Transaction transaction);
        void Withdraw(Transaction transaction);
        void Payment(Transaction transaction);
    }
}