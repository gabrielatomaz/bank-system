using System.Collections.Generic;
using AutoMapper;
using BankSystem.Application.DataTransferObjects;
using BankSystem.Domain;

namespace BankSystem.Application.Mappers
{
    public class AccountDTOMapper : Profile
    {
        public AccountDTOMapper() {
            CreateMap<Account, AccountDTO>();
            CreateMap<IEnumerable<Account>, List<AccountDTO>>();
            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<IEnumerable<Account>, List<AccountDTO>>().ReverseMap();
        }
    }
}