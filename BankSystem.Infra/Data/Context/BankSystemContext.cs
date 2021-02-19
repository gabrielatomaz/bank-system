using BankSystem.Domain;
using BankSystem.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Data.Models {
	public class BankSystemContext : DbContext {
		public BankSystemContext() { }
		public BankSystemContext(DbContextOptions<BankSystemContext> options) : base (options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySQL("server=localhost;database=bank_system;user=root;password=gabriela1772");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserMapping());
			modelBuilder.ApplyConfiguration(new AccountMapping());
			modelBuilder.ApplyConfiguration(new TransactionMapping());
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Account> Accounts { get; set; }
		public DbSet<Transaction> TransactionS { get; set; }
	}
}