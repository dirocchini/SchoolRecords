using SchoolRecords.Domain.Entities.Base;
using System.Linq.Expressions;

namespace SchoolRecords.Domain.Interfaces.Base
{
    public interface IBaseRepository<TEntity> : IDisposable
          where TEntity : BaseEntity
    {
        TEntity Add(TEntity model);

        IList<TEntity> AddRange(IList<TEntity> model);

        TEntity GetById(int id);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAllActive();

        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> expression, bool noTracking = false);

        IQueryable<TEntity> GetBy(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate, params string[] includes);

        void Update(TEntity obj);

        int SaveChanges();

        Task SaveChangesAsync();
    }
}
