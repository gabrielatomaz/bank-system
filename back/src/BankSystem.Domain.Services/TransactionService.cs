using BankSystem.Domain.Core.Interfaces.Repositories;
using BankSystem.Domain.Core.Interfaces.Services;

namespace BankSystem.Domain.Services
{
    public class TransactionService : BaseService<Transaction>, ITransactionService
    {
         private readonly ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transactionRepository) : base(transactionRepository)
            => _transactionRepository = transactionRepository;
    }
}