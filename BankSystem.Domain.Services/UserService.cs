using BankSystem.Domain.Core.Interfaces.Repositories;
using BankSystem.Domain.Core.Interfaces.Services;

namespace BankSystem.Domain.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) : base(userRepository)
            => _userRepository = userRepository;
    }
}