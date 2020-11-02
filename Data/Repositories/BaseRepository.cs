using System;
using System.Collections.Generic;
using DomainLogic.Repositories;

namespace Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAllEntity()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entitry)
        {
            throw new NotImplementedException();
        }
    }
}
