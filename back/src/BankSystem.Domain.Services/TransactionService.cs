using System;
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

        public void Deposit(Transaction transaction)
        {
            transaction.TransactionType = TransactionType.Deposit;

            var account = _accountRepository.GetBy(transaction.AccountId);
            
            var value = transaction.Value;
            account.EncreaseBalance(value);

            _transactionRepository.Add(transaction);
        }


        public void Payment(Transaction transaction)
        {
            transaction.TransactionType = TransactionType.Payment;

            var account = _accountRepository.GetBy(transaction.AccountId);
            
            var value = transaction.Value;
            CheckBalance(account, value);
            account.DecreaseBalance(value);

            transaction.Account = account;

            _transactionRepository.Add(transaction);
        }

        public void Withdraw(Transaction transaction)
        {
            transaction.TransactionType = TransactionType.Withdraw;

            var account = _accountRepository.GetBy(transaction.AccountId);

            var value = transaction.Value;
            CheckBalance(account, value);
            account.DecreaseBalance(value);

            transaction.Account = account;

            _transactionRepository.Add(transaction);
        }

        private void CheckBalance(Account account, double value) 
        {
            if (!account.hasBalance(value)) throw new InvalidOperationException("Sorry, but you don't have enough money in your account!");
        }
    }
}