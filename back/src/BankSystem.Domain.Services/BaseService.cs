using System.Collections.Generic;
using BankSystem.Domain.Core.Interfaces.Repositories;
using BankSystem.Domain.Core.Interfaces.Services;

namespace BankSystem.Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository) =>
            _baseRepository = baseRepository;

        public void Add(TEntity entity)
        {
            _baseRepository.Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public TEntity GetBy(int id)
        {
            return _baseRepository.GetBy(id);
        }

        public void Remove(TEntity entity)
        {
            _baseRepository.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _baseRepository.Update(entity);
        }
    }
}