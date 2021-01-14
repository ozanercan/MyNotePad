using Microsoft.EntityFrameworkCore;
using MyNotePad.Core.DataAccess.RepositoryPattern.Abstract;
using MyNotePad.Core.DataAccess.Results.Abstract;
using MyNotePad.Core.Entities.Abstract;
using System.Threading.Tasks;

namespace MyNotePad.Core.DataAccess.RepositoryPattern.Concrete
{
    public class RepositoryFull<TEntity, TContext> : RepositoryBase<TEntity, TContext>, IRepositoryFull<TEntity>
         where TEntity : class, IBaseEntity, IErasableEntity, new()
        where TContext : DbContext, new()
    {
        public async Task<IDalResult> ChangeIsDeletedColumn(TEntity entity, bool isDeletedState)
        {
            entity.IsDeleted = isDeletedState;
            return await this.UpdateAsync(entity);
        }
    }
}
