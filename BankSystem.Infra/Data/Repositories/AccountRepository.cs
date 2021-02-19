using BankSystem.Domain;
using BankSystem.Domain.Core.Interfaces.Repositories;
using Data.Models;

namespace BankSystem.Infra.Data.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        private readonly BankSystemContext _bankSystemContext;
        
        public AccountRepository(BankSystemContext bankSystemContext) : base(bankSystemContext)
            => _bankSystemContext = bankSystemContext;
    }
}