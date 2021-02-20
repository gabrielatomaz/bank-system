using System.Collections.Generic;
using BankSystem.Application.DataTransferObjects;
using BankSystem.Application.Interfaces;
using BankSystem.Domain;
using BankSystem.Domain.Core.Interfaces.Services;

using static BankSystem.Application.Mappers.ObjectMapper;

namespace BankSystem.Application
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserService _userService;

        public UserApplicationService(IUserService userService)
        {
            _userService = userService;
        }

        public void Add(UserDTO userDTO)
        {
            var user = Mapper.Map<User>(userDTO);

            _userService.Add(user);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var users = _userService.GetAll();

            return Mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public UserDTO GetBy(int id)
        {
            var user = _userService.GetBy(id);

            return Mapper.Map<UserDTO>(user);
        }

        public void Remove(int id)
        {
            var user = _userService.GetBy(id);

            _userService.Remove(user);
        }

        public void Update(int id, UserDTO userDTO)
        {
            var user = Mapper.Map<User>(userDTO);
            user.Id = id;

            _userService.Update(user);
        }
    }
}