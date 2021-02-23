using BankSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSystem.Infra.Data.Mappings
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(account => account.Id);

            builder.Property(account => account.Balance)
                .IsRequired();

            builder.HasOne(account => account.User)
                .WithOne(user => user.Account);

            builder.HasData(Seed());
        }

        public Account Seed()
        {
            return new Account
            {
                Id = 1,
                Agency = 1111,
                Number = 99999999,
                Balance = 1500,
                UserId = 1
            };
        }
    }
}