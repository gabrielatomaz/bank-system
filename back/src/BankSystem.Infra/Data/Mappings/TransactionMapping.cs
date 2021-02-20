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
				.WithMany();
		}
	}
}