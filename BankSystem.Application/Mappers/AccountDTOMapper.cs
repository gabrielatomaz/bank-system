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
            CreateMap<List<Account>, List<AccountDTO>>();
        }
    }
}