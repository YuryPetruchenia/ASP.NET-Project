using Data.Context;
using DomainLogic.UnitOfWork;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDataContext db;

        public UnitOfWork(IDataContext db)
        {
            this.db = db;
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return db.Set<TEntity>();
        }

        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class
        {
            return db.Entry<TEntity>(entity);
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}
