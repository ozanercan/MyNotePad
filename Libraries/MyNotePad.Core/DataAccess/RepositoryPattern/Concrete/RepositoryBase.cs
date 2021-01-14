using Microsoft.EntityFrameworkCore;
using MyNotePad.Core.DataAccess.RepositoryPattern.Abstract;
using MyNotePad.Core.DataAccess.Results.Abstract;
using MyNotePad.Core.DataAccess.Results.Concrete;
using MyNotePad.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyNotePad.Core.DataAccess.RepositoryPattern.Concrete
{
    public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
         where TEntity : class, IBaseEntity, new()
        where TContext : DbContext, new()
    {
        private readonly DbContext _dbContext;
        private IQueryable<TEntity> _query;

        public RepositoryBase()
        {
            _dbContext = new TContext();
            Query = Entities;
        }
        private IQueryable<TEntity> Query
        {
            get { return _query; }
            set { _query = value; }
        }
        private IQueryable<TEntity> GetAll
        {
            get { return Query; }
        }
        private IQueryable<TEntity> GetAllNoTracking
        {
            get { return Query.AsNoTracking(); }
        }

        public DbSet<TEntity> Entities { get { return _dbContext.Set<TEntity>(); } }

        public async Task<IDalDataResult<TEntity>> CreateAsync(TEntity entity)
        {
            bool isCommited = false;
            Exception exception = null;
            try
            {
                await Entities.AddAsync(entity);
                var commitResult = await CommitAsync();

                if (commitResult.Exception != null)
                    exception = commitResult.Exception;

                isCommited = commitResult.IsCommited;
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            return new DalDataResult<TEntity>(isCommited, exception, entity);
        }


        public async Task<IDalResult> HardDelete(TEntity entity)
        {
            bool isCommited = false;
            Exception exception = null;
            try
            {
                Entities.Remove(entity);
                var commitResult = await CommitAsync();
                isCommited = commitResult.IsCommited;
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            return new DalResult(isCommited, exception);
        }

        public async Task<IDalResult> UpdateAsync(TEntity entity)
        {
            bool isCommited = false;
            Exception exception = null;
            try
            {
                var entry = Entities.Update(entity);
                var commitResult = await CommitAsync();
                isCommited = commitResult.IsCommited;
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            return new DalResult(isCommited, exception);
        }

        public async Task<IDalResult> CommitAsync()
        {
            bool isCommited = false;
            Exception exception = null;
            try
            {
                int commitIntegerResult = await _dbContext.SaveChangesAsync();

                if (commitIntegerResult != -1)
                    isCommited = true;
                else
                    isCommited = false;
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            return new DalResult(isCommited, exception);
        }

        public async Task<IDalDataResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            Exception exception = null;
            TEntity entity = null;
            try
            {
                foreach (var item in includes)
                    Query = Query.Include(item);

                IQueryable<TEntity> query = GetAll.Where(expression);

                if (await query.AnyAsync())
                    entity = await query.FirstAsync();

            }
            catch (Exception ex)
            {
                exception = ex;
                Debug.WriteLine($"--Hata-- {ex.Message}");
            }

            return new DalDataResult<TEntity>(false, exception, entity);
        }

        public async Task<IDalDataResult<List<TEntity>>> GetListAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            Exception exception = null;
            List<TEntity> entities = null;
            try
            {
                foreach (var item in includes)
                    Query = Query.Include(item);

                IQueryable<TEntity> query;

                if (expression == null)
                    query = GetAll;
                else
                    query = GetAll.Where(expression);

                if (await query.AnyAsync())
                    entities = await query.ToListAsync();

            }
            catch (Exception ex)
            {
                exception = ex;
                Debug.WriteLine($"--Hata-- {ex.Message}");
            }

            return new DalDataResult<List<TEntity>>(false, exception, entities);
        }
    }
}
