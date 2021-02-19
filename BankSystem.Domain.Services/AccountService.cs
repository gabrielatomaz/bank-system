using BankSystem.Domain.Core.Interfaces.Repositories;
using BankSystem.Domain.Core.Interfaces.Services;

namespace BankSystem.Domain.Services
{
    public class AccountService : BaseService<Account>, IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository) : base(accountRepository)
            => _accountRepository = accountRepository;
    }
}