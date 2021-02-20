using BankSystem.Domain;
using BankSystem.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Data.Models {
	public class BankSystemContext : DbContext {
		public BankSystemContext(DbContextOptions<BankSystemContext> options) 
			: base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserMapping());
			modelBuilder.ApplyConfiguration(new AccountMapping());
			modelBuilder.ApplyConfiguration(new TransactionMapping());
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Account> Accounts { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
	}
}