using System.Collections.Generic;
using System.Linq;
using BankSystem.Domain;
using BankSystem.Domain.Core.Interfaces.Repositories;
using Data.Models;

namespace BankSystem.Infra.Data.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        private readonly BankSystemContext _bankSystemContext;
        
        public TransactionRepository(BankSystemContext bankSystemContext) : base(bankSystemContext)
            => _bankSystemContext = bankSystemContext;

        public IEnumerable<Transaction> GetByAccountId(int accountId)
        {
            return _bankSystemContext.Transactions.Where(transaction => transaction.AccountId == accountId);
        }
    }
}