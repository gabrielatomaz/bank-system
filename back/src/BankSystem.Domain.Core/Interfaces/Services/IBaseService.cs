using System.Collections.Generic;

namespace BankSystem.Domain.Core.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        TEntity GetBy(int id);
        IEnumerable<TEntity> GetAll();
    }
}