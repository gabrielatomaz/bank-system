using System;
using AutoMapper;

namespace BankSystem.Application.Mappers
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;

                config.AddProfile<UserDTOMapper>();
                config.AddProfile<AccountDTOMapper>();
                config.AddProfile<TransactionDTOMapper>();
            });

            var mapper = configuration.CreateMapper();

            return mapper;
        });

        public static IMapper Mapper => Lazy.Value; 
    }
}