using System.Collections.Generic;
using BankSystem.Application.DataTransferObjects;
using BankSystem.Domain;

namespace BankSystem.Application.Interfaces
{
    public interface IAccountApplicationService
    {
        void Add(AccountDTO accountDTO);
        void Update(int id, AccountDTO accountDTO);
        void Remove(int id);
        AccountDTO GetBy(int id);
        IEnumerable<AccountDTO> GetAll();
        Account GetByUserId(int userId);
    }
}