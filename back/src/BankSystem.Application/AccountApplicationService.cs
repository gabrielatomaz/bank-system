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

            return Mapper.Map<IEnumerable<AccountDTO>>(accounts);
        }

        public AccountDTO GetBy(int id)
        {
            var account = _accountService.GetBy(id);

            return Mapper.Map<AccountDTO>(account);;
        }

        public AccountDTO GetByUserId(int userId)
        {
            var account = _accountService.GetByUserId(userId);

            return Mapper.Map<AccountDTO>(account);
        }

        public void Remove(int id)
        {
            var account = _accountService.GetBy(id);

            _accountService.Remove(account);
        }

        public void Update(int id, AccountDTO accountDTO)
        {
            var account = Mapper.Map<Account>(accountDTO);
            account.Id = id;

            _accountService.Update(account);
        }
    }
}