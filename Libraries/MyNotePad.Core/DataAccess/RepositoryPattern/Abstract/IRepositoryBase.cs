using MyNotePad.Core.DataAccess.Results.Abstract;
using MyNotePad.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyNotePad.Core.DataAccess.RepositoryPattern.Abstract
{
    public interface IRepositoryBase<TEntity>
        where TEntity : class, IBaseEntity, new()
    {
        Task<IDalDataResult<TEntity>> CreateAsync(TEntity entity);

        Task<IDalResult> UpdateAsync(TEntity entity);

        Task<IDalDataResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);
        Task<IDalDataResult<List<TEntity>>> GetListAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);

        Task<IDalResult> HardDelete(TEntity entity);

        Task<IDalResult> CommitAsync();
    }
}
