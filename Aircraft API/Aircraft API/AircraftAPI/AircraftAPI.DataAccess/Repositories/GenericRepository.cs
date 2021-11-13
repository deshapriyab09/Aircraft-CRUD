using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AircraftAPI.DataAccess.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;
        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {

            return await context.Set<TEntity>().ToListAsync();
        }

        public virtual TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public virtual TEntity Add(TEntity t)
        {

            context.Set<TEntity>().Add(t);
            context.SaveChanges();
            return t;
        }

        //public virtual async Task<string> AddAsync(TEntity t) //Dsh
        //{
        //    context.Set<TEntity>().Add(t);
        //    await context.SaveChangesAsync();
        //    string msg = "Success";
        //    return msg;
        //}

        public virtual async Task<TEntity> AddAsync(TEntity t)
        {
            context.Set<TEntity>().Add(t);
            await context.SaveChangesAsync();
            return t;
        }



        public virtual TEntity Find(Expression<Func<TEntity, bool>> match)
        {
            return context.Set<TEntity>().SingleOrDefault(match);
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
        {
            return await context.Set<TEntity>().SingleOrDefaultAsync(match);
        }

        public virtual TEntity FindIncluding(Expression<Func<TEntity, bool>> match, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = context.Set<TEntity>().Where(match).AsQueryable();
            foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
            {

                query = query.Include<TEntity, object>(includeProperty);
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> match)
        {
            return context.Set<TEntity>().Where(match).ToList();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        {
            return await context.Set<TEntity>().Where(match).ToListAsync();
        }

        public virtual void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            return await context.SaveChangesAsync();
        }

        public void Delete(int id)  //Desh
        {
            TEntity exist = context.Set<TEntity>().Find(id);
            if (exist != null)
            {
                context.Remove(exist);
                context.SaveChangesAsync();
            }
        }

        public virtual TEntity Update(TEntity t, object key)
        {
            if (t == null)
                return null;
            TEntity exist = context.Set<TEntity>().Find(key);
            if (exist != null)
            {
                context.Entry(exist).CurrentValues.SetValues(t);
                context.SaveChanges();
            }
            return exist;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity t, object key)
        {
            if (t == null)
                return null;
            TEntity exist = await context.Set<TEntity>().FindAsync(key);
            if (exist != null)
            {
                context.Entry(exist).CurrentValues.SetValues(t);
                await context.SaveChangesAsync();
            }
            return exist;
        }

        public int Count()
        {
            return context.Set<TEntity>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await context.Set<TEntity>().CountAsync();
        }

        public virtual void Save()
        {

            context.SaveChanges();
        }

        public async virtual Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        public virtual IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> query = context.Set<TEntity>().Where(predicate);
            return query;
        }

        public virtual TEntity FindByCompositeKey(object key)
        {
            TEntity query = context.Set<TEntity>().Find(key);
            return query;
        }

        public virtual IEnumerable<TEntity> FindByAllIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = context.Set<TEntity>().Where(predicate).AsQueryable();
            foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
            {

                query = query.Include<TEntity, object>(includeProperty);
            }
            return query;
        }

        public virtual async Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public IEnumerable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {

            IQueryable<TEntity> queryable = GetAll().AsQueryable();
            foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include<TEntity, object>(includeProperty);
            }

            return queryable;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
