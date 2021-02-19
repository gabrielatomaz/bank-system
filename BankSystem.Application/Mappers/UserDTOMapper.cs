using System.Collections.Generic;
using AutoMapper;
using BankSystem.Application.DataTransferObjects;
using BankSystem.Domain;

namespace BankSystem.Application.Mappers
{
    public class UserDTOMapper : Profile
    {
        public UserDTOMapper() {
            CreateMap<User, UserDTO>();
            CreateMap<List<User>, List<UserDTO>>();
        }
    }
}