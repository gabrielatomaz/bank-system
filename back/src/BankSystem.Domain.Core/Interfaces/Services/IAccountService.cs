namespace BankSystem.Domain.Core.Interfaces.Services
{
    public interface IAccountService : IBaseService<Account>
    {
        Account GetByUserId(int userId);
    }
}