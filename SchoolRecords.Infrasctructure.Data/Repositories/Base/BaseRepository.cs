using Microsoft.EntityFrameworkCore;
using SchoolRecords.Domain.Entities.Base;
using SchoolRecords.Domain.Interfaces.Base;
using SchoolRecords.Infrasctructure.Data.Context;
using System.Linq.Expressions;

namespace SchoolRecords.Infrasctructure.Data.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
            where TEntity : BaseEntity
    {
        protected readonly SchoolRecordsContext _db;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(SchoolRecordsContext context)
        {
            this._db = context;
            this._dbSet = this._db.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity entity)
        {
            this._dbSet.Add(entity);
            return entity;
        }

        public virtual IList<TEntity> AddRange(IList<TEntity> entity)
        {
            this._dbSet.AddRange(entity);
            return entity;
        }


        public virtual TEntity GetById(int id)
        {
            return this._dbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return this._dbSet;
        }

      
        public virtual IQueryable<TEntity> GetAllActive()
        {
            return this._dbSet.Where(x => x.Active == true);
        }

      
        public virtual IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> expression, bool noTracking = false)
        {
            var query = this.GetAll().Where(expression).AsQueryable();
            return noTracking ? query.AsNoTracking() : query;
        }

     
        public virtual IQueryable<TEntity> GetBy(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate)
        {
            return query.Where(predicate).AsQueryable();
        }

     
        public virtual IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = this.GetAll();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }

            if (predicate != null)
            {
                query = this.GetBy(query, predicate);
            }

            return query;
        }

        public virtual IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate, params string[] includes)
        {
            var query = this.GetAll();

            if (includes != null && includes.Any())
            {
                foreach (var include in includes)
                {
                    if (!string.IsNullOrEmpty(include))
                    {
                        query = query.Include(include);
                    }
                }
            }

            if (predicate != null)
            {
                query = this.GetBy(query, predicate);
            }

            return query;
        }

     
        public virtual IQueryable<TEntity> GetByOrdered<TOrderKey>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TOrderKey>> orderByExp,
            bool ascending,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var query = this.GetBy(predicate, includes);

            query = ascending ? query.OrderBy(orderByExp) : query.OrderByDescending(orderByExp);

            return query;
        }

       
        public virtual void Update(TEntity obj)
        {
            this._dbSet.Update(obj);
        }

  
        public virtual void Remove(Guid id)
        {
            this._dbSet.Remove(this._dbSet.Find(id));
        }

     
        public virtual void Remove(IEnumerable<Guid> ids)
        {
            foreach (var id in ids)
            {
                this.Remove(id);
            }
        }

        public int SaveChanges()
        {
            return this._db.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {

            await this._db.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
