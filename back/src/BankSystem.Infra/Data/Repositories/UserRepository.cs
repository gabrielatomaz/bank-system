using BankSystem.Domain;
using BankSystem.Domain.Core.Interfaces.Repositories;
using Data.Models;

namespace BankSystem.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly BankSystemContext _bankSystemContext;

        public UserRepository(BankSystemContext bankSystemContext) : base(bankSystemContext)
            => _bankSystemContext = bankSystemContext;
    }
}