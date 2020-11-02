using System.Collections.Generic;

namespace DomainLogic.Repositories
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        void Create(TEntity entity);

        void Update(TEntity entitry);

        void Delete(TEntity entity);
    }
}
