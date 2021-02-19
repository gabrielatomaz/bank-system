using System;
using System.Collections.Generic;
using System.Linq;
using BankSystem.Domain.Core.Interfaces.Repositories;
using Data.Models;

namespace BankSystem.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly BankSystemContext _bankSystemContext;

        public BaseRepository(BankSystemContext bankSystemContext) 
            => _bankSystemContext = bankSystemContext;

        public void Add(TEntity entity)
        {
            _bankSystemContext.Set<TEntity>().Add(entity);
            _bankSystemContext.SaveChanges();
        }

        public IEnumerable<TEntity> getAll()
        {
            return _bankSystemContext.Set<TEntity>().ToList();   
        }

        public TEntity getBy(int id)
        {
            return _bankSystemContext.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            _bankSystemContext.Set<TEntity>().Remove(entity);
            _bankSystemContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _bankSystemContext.Set<TEntity>().Update(entity);
            _bankSystemContext.SaveChanges();
        }
    }
}