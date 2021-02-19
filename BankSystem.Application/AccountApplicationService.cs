using System.Collections.Generic;
using BankSystem.Application.DataTransferObjects;
using BankSystem.Application.Interfaces;
using BankSystem.Domain;
using BankSystem.Domain.Core.Interfaces.Services;

using static BankSystem.Application.Mappers.ObjectMapper;

namespace BankSystem.Application
{
    public class AccountApplicationService : IAccountApplicationService
    {
        private readonly IAccountService _accountService;
        public AccountApplicationService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public void Add(AccountDTO accountDTO)
        {
            var account = Mapper.Map<Account>(accountDTO);

            _accountService.Add(account);
        }

        public IEnumerable<AccountDTO> GetAll()
        {
            var accounts = _accountService.GetAll();

            return Mapper.Map<List<AccountDTO>>(accounts);
        }

        public AccountDTO GetBy(int id)
        {
            var account = _accountService.GetBy(id);

            return Mapper.Map<AccountDTO>(account);
        }

        public void Remove(AccountDTO accountDTO)
        {
            var account = Mapper.Map<Account>(accountDTO);

            _accountService.Remove(account);
        }

        public void Update(AccountDTO accountDTO)
        {
            var account = Mapper.Map<Account>(accountDTO);

            _accountService.Update(account);
        }
    }
}