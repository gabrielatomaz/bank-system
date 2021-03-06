namespace BankSystem.Domain.Core.Interfaces.Services
{
    public interface ITransactionService : IBaseService<Transaction>
    {

        void Deposit(Transaction transaction);
        void Withdraw(Transaction transaction);
        void Payment(Transaction transaction);
    }
}