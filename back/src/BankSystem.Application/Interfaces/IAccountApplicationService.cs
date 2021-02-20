using System.Collections.Generic;
using BankSystem.Application.DataTransferObjects;

namespace BankSystem.Application.Interfaces
{
    public interface IAccountApplicationService
    {
        void Add(AccountDTO accountDTO);
        void Update(int id, AccountDTO accountDTO);
        void Remove(int id);
        AccountDTO GetBy(int id);
        IEnumerable<AccountDTO> GetAll();
    }
}