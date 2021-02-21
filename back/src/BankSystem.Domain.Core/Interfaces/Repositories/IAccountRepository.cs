namespace BankSystem.Domain.Core.Interfaces.Repositories
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Account GetByUserId(int userId);
    }
}