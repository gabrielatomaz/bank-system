using System.Collections.Generic;
using BankSystem.Application.DataTransferObjects;

namespace BankSystem.Application.Interfaces
{
    public interface IAccountApplicationService
    {
        void Add(AccountDTO accountDTO);
        void Update(AccountDTO accountDTO);
        void Remove(AccountDTO accountDTO);
        AccountDTO GetBy(int id);
        IEnumerable<AccountDTO> GetAll();
    }
}