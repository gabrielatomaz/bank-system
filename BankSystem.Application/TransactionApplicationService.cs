using System.Collections.Generic;
using BankSystem.Application.DataTransferObjects;
using BankSystem.Application.Interfaces;
using BankSystem.Domain;
using BankSystem.Domain.Core.Interfaces.Services;

using static BankSystem.Application.Mappers.ObjectMapper;

namespace BankSystem.Application
{
    public class TransactionApplicationService : ITransactionApplicationService
    {
        private readonly ITransactionService _transactionService;
        public TransactionApplicationService(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public void Add(TransactionDTO transactionDTO)
        {
            var transaction = Mapper.Map<Transaction>(transactionDTO);

            _transactionService.Add(transaction);
        }

        public IEnumerable<TransactionDTO> GetAll()
        {
            var transactions = _transactionService.GetAll();

            return Mapper.Map<List<TransactionDTO>>(transactions);
        }

        public TransactionDTO GetBy(int id)
        {
            var transaction = _transactionService.GetBy(id);

            return Mapper.Map<TransactionDTO>(transaction);
        }

        public void Remove(TransactionDTO transactionDTO)
        {
            var transaction = Mapper.Map<Transaction>(transactionDTO);

            _transactionService.Remove(transaction);
        }

        public void Update(TransactionDTO transactionDTO)
        {
            var transaction = Mapper.Map<Transaction>(transactionDTO);

            _transactionService.Update(transaction);
        }
    }
}