using System;
using System.Collections.Generic;
using BankSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSystem.Infra.Data.Mappings
{
    public class TransactionMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(transaction => transaction.Id);

            builder.Property(transaction => transaction.TransactionType)
                .IsRequired();

            builder.Property(transaction => transaction.Value)
                .IsRequired();

            builder.Property(transaction => transaction.Description)
                .IsRequired();

            builder.HasOne(transaction => transaction.Account)
                .WithMany(account => account.Transactions)
                .HasForeignKey(transaction => transaction.AccountId);

			builder.HasData(Seed());
        }

        public List<Transaction> Seed()
        {
            return new List<Transaction>() 
			{
                new Transaction 
				{
					Id = 1,
                    AccountId = 1,
                    Date = DateTime.Now,
                    Description = "Description Deposit",
                    TransactionType = TransactionType.Deposit,
                    Value = 1700
                },
				new Transaction 
				{
					Id = 2,
                    AccountId = 1,
                    Date = DateTime.Now,
                    Description = "Description Payment",
                    TransactionType = TransactionType.Payment,
                    Value = 100
                },
				new Transaction 
				{
					Id = 3,
                    AccountId = 1,
                    Date = DateTime.Now,
                    Description = "Description Withdraw",
                    TransactionType = TransactionType.Withdraw,
                    Value = 100
                }
            };
        }
    }
}