using System.Collections.Generic;
using System.Transactions;
using AutoMapper;
using BankSystem.Application.DataTransferObjects;

namespace BankSystem.Application.Mappers
{
    public class TransactionDTOMapper : Profile
    {
        public TransactionDTOMapper() {
            CreateMap<Transaction, TransactionDTO>();
            CreateMap<List<Transaction>, List<TransactionDTO>>();
        }
    }
}