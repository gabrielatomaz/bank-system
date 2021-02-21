using System;
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
        public TransactionApplicationService(ITransactionService transactionService) =>
            _transactionService = transactionService;

        public void Add(TransactionDTO transactionDTO)
        {
            var transaction = Mapper.Map<Transaction>(transactionDTO);

            _transactionService.Add(transaction);
        }

        public void Deposit(TransactionDTO transactionDTO)
        {
            var transaction = Mapper.Map<Transaction>(transactionDTO);

            _transactionService.Deposit(transaction);
        }

        public IEnumerable<TransactionDTO> GetAll()
        {
            var transactions = _transactionService.GetAll();

            return Mapper.Map<IEnumerable<TransactionDTO>>(transactions);
        }

        public TransactionDTO GetBy(int id)
        {
            var transaction = _transactionService.GetBy(id);

            return Mapper.Map<TransactionDTO>(transaction);
        }

        public IEnumerable<TransactionDTO> GetByAccountId(int accountId)
        {
            var transactions = _transactionService.GetByAccountId(accountId);

            return Mapper.Map<IEnumerable<TransactionDTO>>(transactions);
        }

        public void Payment(TransactionDTO transactionDTO)
        {
            var transaction = Mapper.Map<Transaction>(transactionDTO);

            _transactionService.Payment(transaction);
        }

        public void Remove(int id)
        {
            var transaction = _transactionService.GetBy(id);

            _transactionService.Remove(transaction);
        }

        public void Update(int id, TransactionDTO transactionDTO)
        {
            var transaction = Mapper.Map<Transaction>(transactionDTO);
            transaction.Id = id;
            transaction.Date = DateTime.Now;

            _transactionService.Update(transaction);
        }

        public void Withdraw(TransactionDTO transactionDTO)
        {
            var transaction = Mapper.Map<Transaction>(transactionDTO);
            
            _transactionService.Withdraw(transaction);
        }
    }
}