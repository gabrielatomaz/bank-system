using System;
using System.Collections.Generic;
using BankSystem.Domain.Core.Interfaces.Repositories;
using BankSystem.Domain.Core.Interfaces.Services;

namespace BankSystem.Domain.Services
{
    public class TransactionService : BaseService<Transaction>, ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        
        public TransactionService(ITransactionRepository transactionRepository, IAccountRepository accountRepository) : base(transactionRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }

        public IEnumerable<Transaction> GetByAccountId(int accountId)
        {
            return _transactionRepository.GetByAccountId(accountId);
        }

        public void Deposit(Transaction transaction)
        {
            transaction.TransactionType = TransactionType.Deposit;

            var account = _accountRepository.GetBy(transaction.AccountId);
            account.Balance += transaction.Value;

            transaction.Account = account;

            _transactionRepository.Add(transaction);
        }


        public void Payment(Transaction transaction)
        {
            transaction.TransactionType = TransactionType.Payment;

            var account = _accountRepository.GetBy(transaction.AccountId);
            
            if (!account.hasBalance(transaction.Value)) throw new InvalidOperationException("Sorry, but you don't have enough money in yout account!");

            account.Balance -= transaction.Value;

            transaction.Account = account;

            _transactionRepository.Add(transaction);
        }

        public void Withdraw(Transaction transaction)
        {
            transaction.TransactionType = TransactionType.Withdraw;

            var account = _accountRepository.GetBy(transaction.AccountId);
            
            if (!account.hasBalance(transaction.Value)) throw new InvalidOperationException("Sorry, but you don't have enough money in yout account!");

            account.Balance -= transaction.Value;

            transaction.Account = account;

            _transactionRepository.Add(transaction);
        }
    }
}