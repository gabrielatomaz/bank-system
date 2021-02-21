using System.Collections.Generic;
using AutoMapper;
using BankSystem.Application.DataTransferObjects;
using BankSystem.Domain;

namespace BankSystem.Application.Mappers
{
    public class TransactionDTOMapper : Profile
    {
        public TransactionDTOMapper() 
        {
            CreateMap<Transaction, TransactionDTO>();
            CreateMap<IEnumerable<Transaction>, List<TransactionDTO>>();
            CreateMap<Transaction, TransactionDTO>().ReverseMap();
            CreateMap<IEnumerable<Transaction>, List<TransactionDTO>>().ReverseMap();
        }
    }
}