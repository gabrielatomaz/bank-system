using System.Collections.Generic;
using AutoMapper;
using BankSystem.Application.DataTransferObjects;
using BankSystem.Domain;

namespace BankSystem.Application.Mappers
{
    public class UserDTOMapper : Profile
    {
        public UserDTOMapper() 
        {
            CreateMap<User, UserDTO>();
            CreateMap<IEnumerable<User>, List<UserDTO>>();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<IEnumerable<User>, List<UserDTO>>().ReverseMap();
        }
    }
}