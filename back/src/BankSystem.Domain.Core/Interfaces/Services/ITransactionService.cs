using System.Collections.Generic;

namespace BankSystem.Domain.Core.Interfaces.Services
{
    public interface ITransactionService : IBaseService<Transaction>
    {
        IEnumerable<Transaction> GetByAccountId(int accountId);
    }
}