using System.Collections.Generic;
using BankSystem.Application.DataTransferObjects;

namespace BankSystem.Application.Interfaces
{
    public interface IUserApplicationService
    {
        void Add(UserDTO userDTO);
        void Update(UserDTO userDTO);
        void Remove(UserDTO userDTO);
        UserDTO GetBy(int id);
        IEnumerable<UserDTO> GetAll();
    }
}