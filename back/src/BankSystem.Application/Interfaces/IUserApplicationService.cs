using System.Collections.Generic;
using BankSystem.Application.DataTransferObjects;

namespace BankSystem.Application.Interfaces
{
    public interface IUserApplicationService
    {
        void Add(UserDTO userDTO);
        void Update(int id, UserDTO userDTO);
        void Remove(int id);
        UserDTO GetBy(int id);
        IEnumerable<UserDTO> GetAll();
    }
}