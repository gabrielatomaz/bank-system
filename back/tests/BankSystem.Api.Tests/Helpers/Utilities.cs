using System;
using System.Collections.Generic;
using BankSystem.Domain;
using Data.Models;

namespace BankSystem.Api.Tests.Helpers
{
    public class Utilities
    {
        public static void InitializeDbForTests(BankSystemContext db)
        {
            db.Users.Add(GetUser());
            db.Accounts.Add(GetAccount());
            db.Transactions.AddRange(GetTransactions());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(BankSystemContext db)
        {
            db.Transactions.RemoveRange(db.Transactions);
            db.Accounts.RemoveRange(db.Accounts);
            db.Users.RemoveRange(db.Users);
            InitializeDbForTests(db);
        }

        public static User GetUser()
        {
            return new User() 
            {
                Name = "Name"
            };
        }

        public static Account GetAccount()
        {
            return new Account() 
            {
                Agency = 1111,
                Number = 99999999,
                Balance = 1500,
                UserId = 1
            };
        }

        public static List<Transaction> GetTransactions()
        {
            return new List<Transaction>() {
                new Transaction() 
                {
                    Value = 1000,
                    TransactionType = TransactionType.Withdraw,
                    Description = "Test Description Withdraw",
                    AccountId = 1,
                    Date = DateTime.Now
                },
                new Transaction() 
                {
                    Value = 3000,
                    TransactionType = TransactionType.Payment,
                    Description = "Test Description Payment",
                    AccountId = 1,
                    Date = DateTime.Now
                },
                new Transaction() 
                {
                    Value = 100,
                    TransactionType = TransactionType.Payment,
                    Description = "Test Description Payment",
                    AccountId = 1,
                    Date = DateTime.Now
                },
                new Transaction() 
                {
                    Value = 1000,
                    TransactionType = TransactionType.Deposit,
                    Description = "Test Description Deposit",
                    AccountId = 1,
                    Date = DateTime.Now
                },
            };
        }
    }
}