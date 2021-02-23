using BankSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSystem.Infra.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(user => user.Account)
                .WithOne();

			builder.HasData(Seed());
        }

        public User Seed()
        {
            return new User
            {
				Id = 1,
				Name = "Gabriela"
            };
        }
    }
}