using Autofac;
using BankSystem.Application;
using BankSystem.Application.Interfaces;
using BankSystem.Domain.Core.Interfaces.Repositories;
using BankSystem.Domain.Core.Interfaces.Services;
using BankSystem.Domain.Services;
using BankSystem.Infra.Data.Repositories;

namespace BankSystem.Infra.CrossCutting.InversionOfControl
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder) 
        {
            builder.RegisterType<UserApplicationService>().As<IUserApplicationService>();
            builder.RegisterType<AccountApplicationService>().As<IAccountApplicationService>();
            builder.RegisterType<TransactionApplicationService>().As<ITransactionApplicationService>();

            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<AccountRepository>().As<IAccountRepository>();
            builder.RegisterType<TransactionRepository>().As<ITransactionRepository>();
            
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<TransactionService>().As<ITransactionService>();
        }
    }
} 